using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Xml.Linq;

using Impinj.OctaneSdk;

using ssms.DataClasses;
using ssms.Util;

namespace ssms.Pages.Items
{
    public partial class ScanItemsInStore : UserControl
    {
    	int iOperationStatus = 0;
		
        bool busy = false;
        List<LTS.Item> dbList;
        List<inventory> theList = new List<inventory>();
        List<inventory> missing = new List<inventory>();
        List<inventory> found = new List<inventory>();
        public bool config = false;
        List<LTS.Store> listS = new List<LTS.Store>();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        LTS.Settings gstSettings;
        SettingsMain sm = new SettingsMain();
        public List<string> check = new List<string>();

		
		Random gstRand = new Random();
		

		

		//设置控件可用性
		private bool scanItem_chgOper(int iOper)
        {
        	Log.WriteLog(LogType.Trace, "come in scanItem_chgOper");

            switch(iOper)
            {
            	//初始化
                case Macro.SCANITEM_OPR_INIT:
                {
                    bExportPdf.Enabled = true;
            		cbStore.Enabled = true;

					bConnect.Enabled = true;
					
                	lConnect.Visible = false;

					bStart.Enabled = false;
					lStart.Visible = false;

					bStop.Enabled = false;
					lStop.Visible = false;
					
					bBack.Enabled = true;
						
                }
                break;

				//正在连接
				case Macro.SCANITEM_OPR_CONNECTING:
                {
                	bExportPdf.Enabled = false;
            		cbStore.Enabled = false;
					bConnect.Enabled = false;
					
                	lConnect.Text = "Connecting";
                	lConnect.Visible = true;

					//正在连接，不可以开始
					bStart.Enabled = false;
					lStart.Visible = false;
					
					//正在连接，不可以结束
					bStop.Enabled = false;
					lStop.Visible = false;

					
					bBack.Enabled = false;
					
                }
                break;

				//没连接上
				case Macro.SCANITEM_OPR_NOTCONNECT:
                {
                	bExportPdf.Enabled = true;
            		cbStore.Enabled = true;
					bConnect.Enabled = true;
					
                	lConnect.Text = "Not Connected";
                	lConnect.Visible = true;

					//没有连接成功，不可以开始
					bStart.Enabled = false;
					lStart.Visible = false;
					
					//没有连接成功，不可以结束
					bStop.Enabled = false;
					lStop.Visible = false;

					bBack.Enabled = true;
                }
                break;

				//连接上
				case Macro.SCANITEM_OPR_CONNECTED:
                {
                	bExportPdf.Enabled = true;
            		cbStore.Enabled = false;
					bConnect.Enabled = false;
					
                	lConnect.Text = "Connected";
                	lConnect.Visible = true;

					//连接上后，可以开始
					bStart.Enabled = true;
					lStart.Visible = false;
					
					//连接上后，可以结束
					bStop.Enabled = true;
					lStop.Visible = false;

					bBack.Enabled = true;
                }
                break;

				//正在开始
				case Macro.SCANITEM_OPR_STARTING:
                {
                	bExportPdf.Enabled = false;
            		cbStore.Enabled = false;
            		bConnect.Enabled = false;
					
					//在开始阶段，不能进行连接操作
					lConnect.Text = "Connected";
                	lConnect.Visible = false;

					
					lStart.Text = "starting";
					bStart.Enabled = false;
					lStart.Visible = true;
					
					//在开始阶段，不能进行停止操作
					bStop.Enabled = false;
					lStop.Visible = false;

					//在开始阶段，不能进行退出操作
					bBack.Enabled = false;
                }
                break;

				//已经开始
				case Macro.SCANITEM_OPR_STARTED:
                {
                	bExportPdf.Enabled = false;
            		cbStore.Enabled = false;
					bConnect.Enabled = false;
					
                	//在开始阶段，不能进行连接操作
					lConnect.Text = "Connected";
                	lConnect.Visible = false;

					
					lStart.Text = "Started and Reading ...";
					bStart.Enabled = false;
					lStart.Visible = true;
					
					//在已经开始阶段，可以进行停止操作
					bStop.Enabled = true;
					lStop.Visible = false;

					//在开始阶段，不能进行退出操作
					bBack.Enabled = false;
                }
                break;


				//开始失败
				case Macro.SCANITEM_OPR_NOTSTARTED:
                {       
                	bExportPdf.Enabled = true;
            		cbStore.Enabled = false;
					bConnect.Enabled = false;
					
                	//在开始阶段，不能进行连接操作
					lConnect.Text = "Connected";
                	lConnect.Visible = false;

					//连接失败，可以进行重新开始操作
					lStart.Text = "disable to start";
					bStart.Enabled = true;
					lStart.Visible = true;
					
					//开始失败，不可以进行停止操作
					bStop.Enabled = true;
					lStop.Visible = false;

					//可以进行退出操作
					bBack.Enabled = true;
                }
                break;
				
                default:
                {
                    Log.WriteLog(LogType.Error, "error:operation tpye is invaliable");
                    return false;
                }
                break;
            }



			return true;
		}
		
        public ScanItemsInStore()
        {
        	Log.WriteLog(LogType.Trace, "come in ScanItemsInStore");
            InitializeComponent();
        }

        private void scanItem_back_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in scanItem_back_click");
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

        private void scanItem_exportPdf_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in scanItem_exportPdf_click");
            saveFileDialog1.ShowDialog();
        }

        private void scanItem_saveFile_ok(object sender, CancelEventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in scanItem_saveFile_ok");
			
            Object inventory = lbItems.DataSource;
            Object imissing = lbxMissing.DataSource;

            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8);
            string folderPath = saveFileDialog1.FileName + ".pdf";

            //TABLE 1
            //Creating iTextSharp Table from the DataTable data
            Document pdfDoc = new Document(PageSize.A4);

            PdfPTable pdfTable1 = new PdfPTable(1);
            pdfTable1.DefaultCell.Padding = 0;

            pdfTable1.WidthPercentage = 100;
            pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable1.DefaultCell.BorderWidth = 0;



            //Adding Header row

            PdfPCell cell = new PdfPCell(new Phrase("Inventory"));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable1.AddCell(cell);


            //Adding DataRow
            List<string> inven = lbItems.Items.Cast<object>().Select(o => o.ToString()).ToList();
            for (int u = 0; u < inven.Count; u++)
            {
                // pdfTable.AddCell(cell.Value.ToString());
                PdfPCell cellRows = new PdfPCell(new Phrase(inven[u], font));
                int R = 0;
                int G = 0;
                int B = 0;
                if (R == 0 && G == 0 && B == 0)
                {
                    R = 255;
                    G = 255;
                    B = 255;
                }
                cellRows.BackgroundColor = new iTextSharp.text.BaseColor(R, G, B);
                cellRows.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable1.AddCell(cellRows);


            }









            //TABLE2
            //Creating iTextSharp Table from the DataTable data
           // Document pdfDoc = new Document(PageSize.A4);

            PdfPTable pdfTable2 = new PdfPTable(1);
            pdfTable2.DefaultCell.Padding = 0;

            pdfTable2.WidthPercentage = 100;
            pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable2.DefaultCell.BorderWidth = 0;



            //Adding Header row

            PdfPCell cells = new PdfPCell(new Phrase("Missing Inventory"));
            cells.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);
            cells.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable2.AddCell(cells);




            //Adding DataRow
            List<string> miss = lbxMissing.Items.Cast<object>().Select(o => o.ToString()).ToList();
            for (int u = 0; u < miss.Count; u++)
            {
                // pdfTable.AddCell(cell.Value.ToString());
                PdfPCell cellRows = new PdfPCell(new Phrase(miss[u], font));
                int R = 0;
                int G = 0;
                int B = 0;
                if (R == 0 && G == 0 && B == 0)
                {
                    R = 255;
                    G = 255;
                    B = 255;
                }
                cellRows.BackgroundColor = new iTextSharp.text.BaseColor(R, G, B);
                cellRows.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable2.AddCell(cellRows);


            }

            Paragraph writing = new iTextSharp.text.Paragraph("Rfid Reader Management System " + Environment.NewLine + "Inventory Scan Results                " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);
            Paragraph writing2 = new iTextSharp.text.Paragraph(Environment.NewLine + Environment.NewLine + Environment.NewLine);

            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(writing);
                pdfDoc.Add(pdfTable1);
                pdfDoc.Add(writing2);
                pdfDoc.Add(pdfTable2);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void scanItem_load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in scanItem_load");
			
            bStart.Enabled = false;
            bConnect.Enabled = true;
            
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> s = new List<string>();

            for (int i = 0; i < listS.Count; i++)
            {
                s.Add(listS[i].StoreName);
            }

			Log.WriteLog(LogType.Trace, "success to load "+listS.Count+" store names into memery");
			
            cbStore.DataSource = s; //触发store下拉框改变事件

			scanItem_chgOper(Macro.SCANITEM_OPR_INIT);
        }

		//组装item在前台的显示信息
		private inventory scanItem_encodeItemInfo2front(ref LTS.Item stItem, ref LTS.Product stProduct)
		{
			Log.WriteLog(LogType.Trace, "come in scanItem_encodeItemInfo2front");
			
			//组装显示信息
			inventory stInv = new inventory();
			if (null == stInv)
			{	
				Log.WriteLog(LogType.Error, "error to get inventory memery");
				return null;
			}

			if (null == stItem)
			{	
				Log.WriteLog(LogType.Error, "the item param is error");
				return null;
			}
			
			stInv.EPC = stItem.TagEPC;
			stInv.itemID = stItem.ItemID;
			if (stProduct != null)
			{
				stInv.ProductName = stProduct.ProductName;
				stInv.ProductDescription = stProduct.ProductDescription;
			}
			Log.WriteLog(LogType.Trace, "success to encode item["+stInv.itemID+"] info into front:epc["+stInv.EPC+"], product name["+stInv.ProductName+"], product description["+stInv.ProductDescription+"]");

			return stInv;
		}

		//显示指定store下所有的item到list中
		private bool scanItem_item2List(int iStoreId, ref List<inventory> listInv)
        {
			Log.WriteLog(LogType.Trace, "come in scanItem_item2List");
			listInv.Clear();

			List<LTS.Item> listItem = DAT.DataAccess.GetItem().Where(i=>i.StoreID == iStoreId && i.ItemStatus == true).ToList();
			
			if (listItem != null)
			{
				Log.WriteLog(LogType.Trace, "success to get "+listItem.Count+" items from store["+iStoreId+"]");

				if (listItem.Count > 0)
				{
					for (int iIdx = 0; iIdx < listItem.Count; iIdx ++)
					{
						LTS.Item stItem = listItem[iIdx];
						LTS.Product stProduct = DAT.DataAccess.GetProduct().Where(p=>p.ProductID == stItem.ProductID).FirstOrDefault();
						if (stProduct != null)
						{
							Log.WriteLog(LogType.Trace, "success get product["+ stItem.ProductID+"] info: product name["+stProduct.ProductName+"], product description["+stProduct.ProductDescription+"]");
						}
						else
						{
							Log.WriteLog(LogType.Error, "error to get product["+stItem.ProductID+"] info ,it is impossible.");
			
						}

						//组装显示信息
						inventory stInv = scanItem_encodeItemInfo2front(ref stItem, ref stProduct);
						if (stInv != null)
						{
							listInv.Add(stInv);
							Log.WriteLog(LogType.Trace, "success to add item["+stInv.itemID+"] info into inventory list");
						}
						else
						{
							Log.WriteLog(LogType.Error, "error to call scanItem_encodeItemInfo2front");
						}
						
					}
				}

				return true;
			}
			else
			{
				Log.WriteLog(LogType.Error, "error to get item list from store["+iStoreId+"]");
				return false;
			}

			
		}

		private void scanItem_showReaderInfo(bool isShowReader, int iStoreId)
		{
			Log.WriteLog(LogType.Trace, "come in scanItem_showReaderInfo");
			panel1.Controls.Clear();
			panel1.Visible = true;
				
			if (isShowReader)
			{
				//panel1.Controls.Clear();
				//panel1.Visible = true;

				lbReader.Parent = panel1;
				setName.Parent = panel1;
				label3.Parent = panel1;

				Log.WriteLog(LogType.Trace, "success to show reader info");
			}
			else
			{
				lSettingsMsg.Text="there is not avaliable settings in store["+iStoreId+"], please change another machine.";
				lSettingsMsg.Parent = panel1;
                lSettingsMsg.Dock = DockStyle.Fill;
                lSettingsMsg.BringToFront();
				
				Log.WriteLog(LogType.Trace, "success to show error info");
			}
		}

		//将item信息显示在list box控件上
		private bool scanItem_itemList2ListBox(ref List<inventory> listInv)
		{
			List<string> listItemStr = new List<string>();
			
			Log.WriteLog(LogType.Trace, "come in scanItem_itemList2ListBox");
			
			if (listInv == null)
			{
                Log.WriteLog(LogType.Error, "the input params is error");
				return false;
			}

			for (int iIdx = 0; iIdx < listInv.Count; iIdx++)
			{
				//listItemStr.Add(listInv[iIdx].EPC + " " + listInv[iIdx].ProductName + " "+ listInv[iIdx].ProductDescription);
				//Log.WriteLog(LogType.Trace, "success to add item["+listInv[iIdx].itemID+"] with epc ["+listInv[iIdx].EPC+"]  into front");

				lbItems.Items.Add(listInv[iIdx].EPC + " " + listInv[iIdx].ProductName);
				Log.WriteLog(LogType.Trace, "success to add item["+listInv[iIdx].itemID+"] with epc ["+listInv[iIdx].EPC+"]  into front");
				
			}

			//lbItems.DataSource = listItemStr;

			Log.WriteLog(LogType.Trace, "success to load "+listInv.Count+" item(s) info into list box");
			return true;
		}

	
		//当改变store时，显示旗下settings的配置信息
        private void scanItem_cbStore_selectIdxChg(object sender, EventArgs e)
        {
            panel1.Visible = false;
            int index = cbStore.SelectedIndex;
			LTS.Store stStore = listS[index];
            int iStoreId = stStore.StoreID;

			Log.WriteLog(LogType.Trace, "come in scanItem_cbStore_selectIdxChg");

			Log.WriteLog(LogType.Trace, "goto get store["+iStoreId+"] avaliable settings from database");

			try
			{			
				//获取store生效的settings
            	gstSettings = DAT.DataAccess.GetSettings().Where(s => s.StoreID == iStoreId && s.SettingsSelect == true).FirstOrDefault();
            	if (gstSettings != null)
	            {
	                List<LTS.Reader> stReader;
					
					//获取settings配置的readers
	                stReader = DAT.DataAccess.GetReader().Where(y => y.SettingsID == gstSettings.SettingsID).ToList();
					if (stReader == null)
					{
						Log.WriteLog(LogType.Error, "error to get settings["+gstSettings.SettingsID+"] readers info");
						return;
					}
					
					Log.WriteLog(LogType.Trace, "success to get "+stReader.Count+" reader(s) from settings["+gstSettings.SettingsID+"]");

					//提取reader信息，并显示在list box中
	                List<string> sReaderInfo = new List<string>();
	                for (int q = 0; q < stReader.Count; q++)
	                {
	                    sReaderInfo.Add(stReader[q].IPaddress + " :  " + stReader[q].NumAntennas + " antenna(s)");

						Log.WriteLog(LogType.Trace, "success to add reader["+stReader[q].ReaderID+"] with ["+stReader[q].NumAntennas+"] antenna(s) into front");
	                }
	                lbReader.DataSource = sReaderInfo;

					setName.Text = gstSettings.SettingsName;

					//在小窗口显示reader信息
					scanItem_showReaderInfo(true, iStoreId);				

					/*从数据库中获取指定store下的所有item*/
					if (!scanItem_item2List(iStoreId, ref theList))
					{
						Log.WriteLog(LogType.Error, "error to call scanItem_Items2List");
						return;
					}			

					//将items通过list box显示
					if (!scanItem_itemList2ListBox(ref theList))
					{
						Log.WriteLog(LogType.Error, "error to call scanItem_itemList2ListBox");
						return;
					}
					
					
					
	            }
				else
				{				
					Log.WriteLog(LogType.Trace, "there is not avaliable settings in store["+iStoreId+"], please change another store.");

					scanItem_showReaderInfo(false, iStoreId);
				}
			}
			 catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "the exception is:"+ex.Message+".");
				
            	
            }

        }


		
		//使用settings，连接到指定的reader(s)上，并根据settings进行配置reader(s)
        private void scanItem_connect_click(object sender, EventArgs e)
        {
			Log.WriteLog(LogType.Trace, "come in scanItem_connect_click");
			
	        if (gstSettings != null)
            {
            	
				scanItem_chgOper(Macro.SCANITEM_OPR_CONNECTING);
				//if (!Rfid.reader_connectReader(gstSettings.StoreID, gstSettings.SettingsID, impinjrev, ir_handler_readTag, null, null, false))
				if (!Rfid.reader_connectReader(gstSettings.StoreID, gstSettings.SettingsID, impinjrev, null, null, null, false))   
				{
					Log.WriteLog(LogType.Error, "error to call reader_connectReader");

					scanItem_chgOper(Macro.SCANITEM_OPR_NOTCONNECT);
					
					return;
				}
				scanItem_chgOper(Macro.SCANITEM_OPR_CONNECTED);
				
			}
			else
			{
                MessageBox.Show("The Store selected does not have a setting set, please go to the Select Setting page and choose a setting!", "", MessageBoxButtons.OKCancel);
            }

	
        }

        private void scanItem_start_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come ni scanItem_start_click");


            scanItem_chgOper(Macro.SCANITEM_OPR_STARTING);
			
			if (Rfid.reader_start_read(ref impinjrev, ir_handler_readTag, ir_handler_writeTag, ir_reader_checkTag))
			{
				scanItem_chgOper(Macro.SCANITEM_OPR_STARTED);
			}
			else
			{
				Log.WriteLog(LogType.Error, "error to call reader_start2read");
				scanItem_chgOper(Macro.SCANITEM_OPR_NOTSTARTED);
			}


			return;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bExportPdf.Enabled = true;
            cbStore.Enabled = true;
            DialogResult res = MessageBox.Show("You are about to stop scanning, Click OK to Stop Scanning, or Cancel!", "", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == res)
            {

                
                bStart.Enabled = false;
                bStop.Enabled = false;
                bConnect.Enabled = true;
                lStop.Visible = true;
                lStop.Text = "Stopping...";

                for (int i = 0; i < impinjrev.Count; i++)
                {
                    impinjrev[i].ir_stopRead();
                    impinjrev[i].ir_disconnect();

                }
                lStop.Text = "Stopped and Disconnected...";
                lConnect.Visible = false;
                lStart.Visible = false;
                ((Form1)this.Parent.Parent.Parent.Parent).scan = false;
                busy = false;
                bBack.Enabled = true;


            }
        }


		//bool tag_writeTag(ref ImpinjReader stReader, ref TagInfo stTagInfo,string newEpc, ushort usEpcOpId, ushort usPcBitOpId)
		bool tag_writeTag(ImpinjReader stReader, TagInfo stTagInfo,string newEpc, ushort usEpcOpId, ushort usPcBitOpId)
        {
        	Log.WriteLog(LogType.Trace, "come in tag_writeTag");

			string currentEpc;
            ushort currentPcBits;
			currentEpc = stTagInfo.sEpcHx;
			currentPcBits = stTagInfo.usPcBits;

            // Check that the specified EPCs are a valid length
            if ((currentEpc.Length % 4 != 0) || (newEpc.Length % 4 != 0))
            {
                //throw new Exception("EPCs must be a multiple of 16 bits (4 hex chars)");
                Log.WriteLog(LogType.Trace, "EPCs must be a multiple of 16 bits (4 hex chars)");
				return false;;
            }
			
			Log.WriteLog(LogType.Trace, "Adding a write operation to change the EPC from :"+currentEpc+" to "+newEpc+"");

            // Create a tag operation sequence.
            // You can add multiple read, write, lock, kill and QT
            // operations to this sequence.
            TagOpSequence seq = new TagOpSequence();

            // Specify a target tag based on the EPC.
            seq.TargetTag.MemoryBank = MemoryBank.Epc;
            seq.TargetTag.BitPointer = BitPointers.Epc;
            seq.TargetTag.Data = currentEpc;

            // If you are using Monza 4, Monza 5 or Monza X tag chips,
            // uncomment these two lines. This enables 32-bit block writes
            // which significantly improves write performance.
            //seq.BlockWriteEnabled = true;
            //seq.BlockWriteWordCount = 2;

            // Create a tag write operation to change the EPC.
            TagWriteOp writeEpc = new TagWriteOp();
            // Set an ID so we can tell when this operation has executed.
            writeEpc.Id = usEpcOpId;
            // Write to EPC memory
            writeEpc.MemoryBank = MemoryBank.Epc;
            // Specify the new EPC data
            writeEpc.Data = TagData.FromHexString(newEpc);
            // Starting writing at word 2 (word 0 = CRC, word 1 = PC bits)
            writeEpc.WordPointer = WordPointers.Epc;

            // Add this tag write op to the tag operation sequence.
            seq.Ops.Add(writeEpc);

            // Is the new EPC a different length than the current EPC?
            if (currentEpc.Length != newEpc.Length)
            {
                // We need adjust the PC bits and write them back to the 
                // tag because the length of the EPC has changed.
                
                // Adjust the PC bits (4 hex characters per word).
                ushort newEpcLenWords = (ushort)(newEpc.Length / 4);
                ushort newPcBits = PcBits.AdjustPcBits(currentPcBits, newEpcLenWords);

				#if false
                Console.WriteLine("Adding a write operation to change the PC bits from :");
                Console.WriteLine("{0} to {1}\n", currentPcBits.ToString("X4"), newPcBits.ToString("X4"));
				#else
				Log.WriteLog(LogType.Trace, "Adding a write operation to change the PC bits from :"+  currentPcBits.ToString("X4")+" to "+newPcBits.ToString("X4")+".");
				
				#endif

                TagWriteOp writePc = new TagWriteOp();
                writePc.Id = usPcBitOpId;
                // The PC bits are in the EPC memory bank.
                writePc.MemoryBank = MemoryBank.Epc;
                // Specify the data to write (the modified PC bits).
                writePc.Data = TagData.FromWord(newPcBits);
                // Start writing at the start of the PC bits.
                writePc.WordPointer = WordPointers.PcBits;

                // Add this tag write op to the tag operation sequence.
                seq.Ops.Add(writePc);

				//设置tag写标志位
				stTagInfo.iTagWState = Macro.TAG_WRITE_INIT;
            }
			else
			{
				stTagInfo.iTagWState = Macro.TAG_WRITE_MODIFY_LEN;
			}

			
			
            // Add the tag operation sequence to the reader.
            // The reader supports multiple sequences.
            stReader.AddOpSequence(seq);

			Log.WriteLog(LogType.Trace, "success to add operation for tag["+stTagInfo.sTid+"] with ecp op id["+usEpcOpId+"] and pc bit op id["+usPcBitOpId+"]");
			return true;
        }



		/*把tag信息显示到前端*/
		private bool ir_show_tagInfo(TagInfo stTagInfo, bool bOk)
		{
			string sTagInfo = "Tid: "+stTagInfo.sTid +" Epc: " + stTagInfo.sEpc;

			if (bOk == true)
			{
				lbItems.Items.Add(sTagInfo);
			}
			else
			{
				lbxMissing.Items.Add(sTagInfo);
			}

			return true;
		}

		bool tag_queue_showInfo(Queue<TagInfo> stQue)
		{
			Log.WriteLog(LogType.Trace, "come in tag_queue_showInfo");

			if (stQue == null)
			{
				Log.WriteLog(LogType.Error, "the param is null");
				return false;
			}
			
			//遍历当前队列中所有的节点，修改它们的操作步骤
			foreach (TagInfo stTmpInfo in stQue)
			{
                Log.WriteLog(LogType.Trace, "the tag[" + stTmpInfo.sTid + "] step now is [" + stTmpInfo.iTagStep + "].");
			}

			return true;
		}

		/*减少队列中各个节点的操作步骤*/
		bool tag_queue_discreateStep(Queue<TagInfo> stQue)
		{
			Log.WriteLog(LogType.Trace, "come in tag_queue_discreateStep");

			if (stQue == null)
			{
				Log.WriteLog(LogType.Error, "the param is null");
				return false;
			}
			
			//遍历当前队列中所有的节点，修改它们的操作步骤
			foreach (TagInfo stTmpInfo in stQue)
			{
                Log.WriteLog(LogType.Trace, "the tag[" + stTmpInfo.sTid + "] step now is [" + stTmpInfo.iTagStep + "], it will be discrease by 1.");
                stTmpInfo.iTagStep--;
			}

			return true;
		}

		/*从fifo队列中弹出一个节点*/
		TagInfo tag_queue_pop(Queue<TagInfo> stQue)
        {
			Log.WriteLog(LogType.Trace, "come in tag_queue_pop");

			TagInfo stTagInfo = null;

			try
			{
				if (stQue.Count == 0)
				{
					Log.WriteLog(LogType.Error, "error:1、there is not tag in queue list.");
					return null;
				}
			
				/*tag出队列*/
				stTagInfo = stQue.Dequeue();
				if (stTagInfo == null)
	        	{
					Log.WriteLog(LogType.Error, "error:2、there is not tag in queue list.");
					return null;
				}

				return stTagInfo;
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "the execption is "+ex.Message+"");
				return null;
			}
		}
		
		//把tag插入入场队列
        public bool ir_handler_readTag(TagInfo stTagInfo, EventArgs e, Queue<TagInfo> stRQue, ref Mutex stMutex)
		{
        	Log.WriteLog(LogType.Trace, "come in ir_handler_readTag");

			if (stTagInfo == null || stRQue == null || stMutex == null)
			{
				Log.WriteLog(LogType.Error, "the params is null");
				return false;
			}

			/*====================更新读队列现有节点操作步骤====================*/
			//锁临界资源
			stMutex.WaitOne();

			//遍历当前队列中所有的节点，修改它们的操作步骤
			if (!tag_queue_discreateStep(stRQue))
			{
				/*没有更新操作步骤成功，但是 不能影响新加入标签的处理*/
				Log.WriteLog(LogType.Error, "error to call tag_queue_discreateStep for read queue");
			}
			
			#if false
            //debug
			tag_queue_showInfo(stRQue);
			#endif

			/*====================插入读队列====================*/
			/*插入fifo队列*/
			stRQue.Enqueue(stTagInfo);
			Log.WriteLog(LogType.Trace, "success to add tag["+stTagInfo.sTid+"] into queue");
			//释放临界资源
            stMutex.ReleaseMutex();

            return true;
            
        }

		//判断fifo队列中的节点是否可用
		void tag_isTagInfoAvailable(TagInfo stTagInfo, string sTId)
        {
        	Log.WriteLog(LogType.Trace, "come in tag_isTagInfoAvailable");
			
        	//必须保证进场顺序和写顺序一致
            if (!string.Equals(sTId, stTagInfo.sTid))
            {
				//tag在流水线上顺序和内存中的顺序以不一致，不再处理该 tag
				stTagInfo.iTagState = Macro.TAG_STATE_ERROR;
				Log.WriteLog(LogType.Error, "error:the tag["+stTagInfo.sTid+"] in queue is not equals with the trigger tag["+sTId+"], this is impossible, set the tag state into error.");
			}

			//必须保证tag的step是写step
			if (stTagInfo.iTagStep != Macro.TAG_STEP_DONE_WIRTE)
			{
				//tag在内存的步骤出错，不再处理该 tag
				stTagInfo.iTagState = Macro.TAG_STATE_ERROR;
				Log.WriteLog(LogType.Error, "error:the tag["+stTagInfo.sTid+"] in queue step is ["+stTagInfo.iTagStep+"],not equere step["+ Macro.TAG_STEP_DONE_WIRTE+"], set the state into error.");
			}
			
			Log.WriteLog(LogType.Trace, "success confirm thetid["+stTagInfo.sTid+"] in tag info is equal with trigger tid["+sTId+"] and in step["+Macro.TAG_STEP_DONE_WIRTE+"].");
			
            return ;
		}
		
		/*参数：
		*EventArgs e, 
		*ImpinjReader stReader, 发起读写事件的读写器;
		*string sTagId, 被处理的tag;
		*Queue<TagInfo> stRList, 内存读队列;
		*ref Mutex stRMutex,读队列锁;
		*Queue<TagInfo> stWList, 内存写队列;
		*ref Mutex stWMutex,内存写锁
		*描述:对触发写操作的读写器进行写操作*/
        bool ir_handler_writeTag(EventArgs e, ImpinjReader stReader, string sTagId, Queue<TagInfo> stRQue, 
        	ref Mutex stRMutex, Queue<TagInfo> stWQue, ref Mutex stWMutex, ref ushort usEpcOpId, ref ushort usPcBitOpId,
        	Dictionary<int, TagInfo> stDic)
        {
        	Log.WriteLog(LogType.Trace, "come in ir_handler_writeTag");

			if (stRQue == null|| stWQue == null)
			{
				Log.WriteLog(LogType.Error, "the   params with queue is null");
				return false;
			}

			if (stRMutex == null|| stWMutex == null)
			{
				Log.WriteLog(LogType.Error, "the    params with mutex is null");
				return false;
			}
			
			//锁临界资源
			stRMutex.WaitOne();

			/*弹出fifo队列的首节点*/
			TagInfo stTagInfo = tag_queue_pop(stRQue);
			if (stTagInfo == null)
        	{
				Log.WriteLog(LogType.Error, "error:、there is not tag in input queue, but the write process is triggered by tag["+sTagId+"], this is impossible.");
				//释放临界资源
            	stRMutex.ReleaseMutex();
				return false;
			}
	
			//释放临界资源
            stRMutex.ReleaseMutex();
			Log.WriteLog(LogType.Trace, "success get a tag info["+stTagInfo.sTid+"] from queue by tid["+sTagId+"] trigger.");
			
			/*====================节点合法性判断====================*/
			tag_isTagInfoAvailable(stTagInfo, sTagId);

			/*====================进行写操作====================*/
			//如果tag的状态不为ok，则不需要进行写操作
			if (stTagInfo.iTagState == Macro.TAG_STATE_ERROR)
			{
				Log.WriteLog(LogType.Warning, "the tag["+stTagInfo.sTid+"] state is error, so no need to write epc into it.");
			}
			else
			{
                int iRnd = gstRand.Next(100, 65535);
                usEpcOpId    = (ushort)iRnd;
				usPcBitOpId = (ushort)(usEpcOpId+1);
				
				//对tag进行写操作
				if (!tag_writeTag(stReader, stTagInfo, "55556666777788889999", usEpcOpId, usPcBitOpId))
				{
					stTagInfo.iTagState = Macro.TAG_STATE_ERROR;
					Log.WriteLog(LogType.Trace, "error:set tag["+stTagInfo.sTid+"]write operation error, so set its state into error");
				}

				//tag加入dic字典
				stDic.Add(usEpcOpId, stTagInfo);
				Log.WriteLog(LogType.Trace, "success to put tag[" + stTagInfo.sTid + "] into dictionary with ecp op id["+usEpcOpId+"].");
			}

			/*====================插入写队列====================*/
			//加入写队列
			stWMutex.WaitOne();

			//遍历写队列中所有的节点，修改它们的操作步骤
			if (!tag_queue_discreateStep(stWQue))
			{
				/*没有更新操作步骤成功，但是 不能影响新加入标签的处理*/
				Log.WriteLog(LogType.Error, "error to call tag_queue_discreateStep for write queue");
			}

			//更新节点的操作步骤
			stTagInfo.iTagStep--;//操作步骤从TAG_STEP_DONE_WIRTE变成4
			//添加新节点
			stWQue.Enqueue(stTagInfo);
			
			//释放临界资源
            stWMutex.ReleaseMutex();

			Log.WriteLog(LogType.Trace, "success to put tag info with tid["+stTagInfo.sTid+"] into write queue");
            return true;

        }

        bool ir_reader_checkTag(ImpinjReader stReader, string sTagId, string sEpc, Queue<TagInfo> stWList,  Mutex stWMutex)
        {
        	Log.WriteLog(LogType.Trace, "come in ir_reader_checkTag");

			Log.WriteLog(LogType.Trace, "the trigger tag id is "+sTagId+", and the confirm epc is "+sEpc+"");

			stWMutex.WaitOne();

			if (stWList.Count == 0)
			{
				Log.WriteLog(LogType.Error, "error:there is not tag in the write list, but the check process is trigger by tag["+sTagId+"], this is impossible ");
				//释放临界资源
            	stWMutex.ReleaseMutex();
				return false;
			}

			/*tag出队列*/
			TagInfo stTagInfo = stWList.Dequeue();
			if (stTagInfo == null)
        	{
				Log.WriteLog(LogType.Error, "error:there is not tag in write list, but the check  process is triggered by tag["+sTagId+"], this is impossible.");
				//释放临界资源
            	stWMutex.ReleaseMutex();
				return false;
			}

			stWMutex.ReleaseMutex();

			/*====================节点合法性判断====================*/
            //必须保证进场顺序和写顺序一致
            if (!string.Equals(sTagId, stTagInfo.sTid))
            {
				//tag在流水线上顺序和内存中的顺序以不一致，不再处理该 tag
				Log.WriteLog(LogType.Error, "error:the tag["+stTagInfo.sTid+"] in queue is not equals with the trigger tag["+sTagId+"], this is impossible, set the tag into error.");

				goto proc_err_tag;
			}

			//必须保证tag的step是写step
			if (stTagInfo.iTagStep != Macro.TAG_STEP_DONE_CHECK)
			{
				//tag在内存的步骤出错，不再处理该 tag
				Log.WriteLog(LogType.Error, "error:the tag["+stTagInfo.sTid+"] in queue step is ["+stTagInfo.iTagStep+"],not equere step["+ Macro.TAG_STEP_DONE_WIRTE+"], set the tag into error.");
				goto proc_err_tag;
			}

			/*====================进行检查操作====================*/
			//如果tag的状态不为ok，则不需要进行检查操作
			if (stTagInfo.iTagState == Macro.TAG_STATE_ERROR)
			{
				Log.WriteLog(LogType.Trace, "the tag["+stTagInfo.sTid+"] state is error, so no need to check epc with it.");
				goto proc_err_tag;
			}
			else if(stTagInfo.iTagWState != Macro.TAG_WRITE_FINISH)
			{
				Log.WriteLog(LogType.Trace, "the tag["+stTagInfo.sTid+"] write state is ["+stTagInfo.iTagWState +"], not equal with["+Macro.TAG_WRITE_FINISH+"], so no need to check epc with it.");
				goto proc_err_tag;
			}
			else if (stTagInfo.sEpc != sEpc)
			{
				Log.WriteLog(LogType.Trace, "the epc["+sEpc+"] from trigger is not equal with the epc["+stTagInfo.sEpc+"] in memery , so take the tag off from the flow.");
				goto proc_err_tag;
			}

			Log.WriteLog(LogType.Trace, "success to write epc["+stTagInfo.sEpc+"] into tag["+stTagInfo.sTid+"]");

			//在前台显示，保存到数据库等操作
			ir_show_tagInfo(stTagInfo, true);
            return true;


			//发送gpo信号，剔除错误的tag
			proc_err_tag:
			Log.WriteLog(LogType.Trace, "goto send gpo signal for tag["+sTagId+"]");
			/*显示到前端*/
			ir_show_tagInfo(stTagInfo, false);
			return true;  
			
			
        }


        void populate()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
            	/*把找到的加载到前端显示*/
                lbItems.DataSource = null;
                lbItems.Items.Clear();
	            for(int i = 0; i < found.Count; i++)
	            {
	                lbItems.Items.Add("ItemID: " + found[i].itemID + "  Product: " + found[i].ProductName + "  Tag EPC: "+ found[i].EPC);
	            }
            
				/*把没有找到的加载到前端显示*/
            	lbxMissing.DataSource = null;
            	lbxMissing.Items.Clear();
            	for (int i = 0; i < missing.Count; i++)
	            {
	                lbxMissing.Items.Add("ItemID: " + missing[i].itemID + "  Product: " + missing[i].ProductName + "  Tag EPC: " + missing[i].EPC);
	            }
            }));

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }

}

    


