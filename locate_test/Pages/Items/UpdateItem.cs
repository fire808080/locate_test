using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ssms.DataClasses;
using ssms.Util;


namespace ssms.Pages.Items
{
    public partial class UpdateItem : UserControl

    {
        string oldEPC;
        //Timer ScanTimer = new Timer();
        System.Timers.Timer timer;
        int time = 0;
		int giItemId = 0; //保存被选中的item的在数据库中的id
		
        List<LTS.Item> it = new List<LTS.Item>();
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Store> listS;
        List<LTS.Barcode> listBar;
        List<DataClasses.ItemMain> imList = new List<ItemMain>();
        SettingsMain sm = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";

        public UpdateItem()
        {
        	Log.WriteLog(LogType.Trace, "come in UpdateItem");
            InitializeComponent();
        }

        private void updateItem_load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_load");

			
            //load store names into combo box from db
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            cbStore.DataSource = S;
			if ( listS.Count > 1)
			{
				cbStore.SelectedIndex = 0;
			}

            //load barcode into combo box from db
            listBar = DAT.DataAccess.GetBarcode().ToList();
            List<string> Ba = new List<string>();

            for (int x = 0; x < listBar.Count; x++)
            {
                Ba.Add(listBar[x].BarcodeNumber);
            }
			
            cbBarcode.DataSource = Ba;  //会触发select index change 事件
			if ( listBar.Count > 1)
			{
				cbBarcode.SelectedIndex = 0;
			}
			

            List<LTS.Item> i = new List<LTS.Item>();
            i = DAT.DataAccess.GetItem().ToList();//list from db
            imList = new List<ItemMain>();

            for (int x = 0; x < i.Count; x++)
            {
                ItemMain im = new ItemMain();
                //assign the item info to the ItemMain object
                im.itemID = i[x].ItemID;
                im.EPC = i[x].TagEPC;
                im.ItemStatus = i[x].ItemStatus;
                im.ProductID = i[x].ProductID;
                im.StoreID = i[x].StoreID;

				Log.WriteLog(LogType.Trace, "goto load item["+im.itemID+"] detail info from database, the summary info is:epc["+im.EPC+"], item status["+im.ItemStatus+"],"+
					 "product id["+im.ProductID+"], store id["+im.StoreID+"]");
				
                //get the specific product and assign the info to the ItemMain object
                LTS.Product p = new LTS.Product();

                p = DAT.DataAccess.GetProduct().Where(h => h.ProductID == im.ProductID).FirstOrDefault();
				if (null == p)
				{
					Log.WriteLog(LogType.Error, "error to get product["+im.ProductID+"] info while loading item["+im.itemID+"] detail info.");
					continue;
				}

                im.ProductName = p.ProductName;
                im.ProductDescription = p.ProductDescription;
                im.BrandID = p.BrandID;
                im.CategoryID = p.CategoryID;
                im.BarcodeID = p.BarcodeID;

                //get the specific store and assign the info to the ItemMain object
                LTS.Store s = new LTS.Store();
                s = DAT.DataAccess.GetStore().Where(j => j.StoreID == im.StoreID).FirstOrDefault();
				if (null == s)
				{
					Log.WriteLog(LogType.Error, "error to get store["+im.StoreID+"] info while loading item["+im.itemID+"] detail info.");
					continue;
				}
                im.StoreName = s.StoreName;
                im.StoreLocation = s.StoreLocation;

                //get the specific brand and assign the info to the ItemMain object
                LTS.Brand b = new LTS.Brand();
                b = DAT.DataAccess.GetBrand().Where(y => y.BrandID == im.BrandID).FirstOrDefault();
				if (null == b)
				{
					Log.WriteLog(LogType.Error, "error to get brand["+im.BrandID+"] info while loading item["+im.itemID+"] detail info.");
					continue;
				}
                im.BrandName = b.BrandName;
                im.BrandDescription = b.BrandDescription;

                //get the sepcific category and assign the info to the ItemMain object
                LTS.Category c = new LTS.Category();
                c = DAT.DataAccess.GetCategory().Where(z => z.CategoryID == im.CategoryID).FirstOrDefault();
				if (null == c)
				{
					Log.WriteLog(LogType.Error, "error to get category["+im.CategoryID+"] info while loading item["+im.itemID+"] detail info.");
					continue;
				}
                im.CategoryName = c.CategoryName;
                im.CategoryDescription = c.CategoryDescription;

                //get the sepcific category and assign the info to the ItemMain object
                LTS.Barcode ba = new LTS.Barcode();
                ba = DAT.DataAccess.GetBarcode().Where(a => a.BarcodeID == im.BarcodeID).FirstOrDefault();
				if (null == ba)
				{
					Log.WriteLog(LogType.Error, "error to get barcode["+im.BarcodeID+"] info while loading item["+im.itemID+"] detail info.");
					continue;
				}
                im.BarcodeNumber = ba.BarcodeNumber;

                imList.Add(im);
                dgvItem.Rows.Add(im.itemID, im.EPC, im.ProductName, im.ProductDescription, im.BarcodeNumber, im.BrandName, im.CategoryName
                    , im.ItemStatus, im.StoreName);

				Log.WriteLog(LogType.Trace, "success to load item["+im.itemID+"] detail info:epc["+im.EPC+"], productName["+im.ProductName+"], productDesciption["+im.ProductDescription+"]" +
					"barcode["+im.BarcodeNumber+"], brandName["+im.BrandName+"], categoryName["+im.CategoryName+"], itemStatus["+im.ItemStatus+"], storeName["+im.StoreName+"]");
            }
        }

        //to change the content of the small panel
        public void updateItem_changeView<T>() where T : Control, new()
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_changeView");
            try
            {
                panel1.Controls.Clear();
                T find = new T();
                find.Parent = panel1;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }

        private void updateItem_addStore_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_addStore_click");
			
            bUpdate.Enabled = false;
            bRfidSearch.Enabled = false;
            bSearch.Enabled = false;
            bRfid.Enabled = false;

            tbEpc.Enabled = false;
            textBox3.Enabled = false;

            cbStore.Enabled = false;
            cbBarcode.Enabled = false;
            dgvItem.Enabled = false;

            updateItem_changeView<Store.AddStoreSmall>();
        }


        //after a store is added in the small panel you need to update the combobox
        public void updateItem_updateStore()
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_updateStore");
			
            panel1.Controls.Clear();
            cbStore.DataSource = null;
            if (listS != null)
            {
                listS.Clear();
            }

			/*更新store信息到下拉框*/
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();
            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            cbStore.DataSource = S;

			Log.WriteLog(LogType.Trace, "success to reload "+listS.Count+" store names from database");
			
            bUpdate.Enabled = true;

            bRfidSearch.Enabled = true;
            bSearch.Enabled = true;
            bRfid.Enabled = true;

            tbEpc.Enabled = true;
            textBox3.Enabled = true;

            cbStore.Enabled = true;
            cbBarcode.Enabled = true;
            dgvItem.Enabled = true;
        }

        private void updateItem_back_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_back_click");
			
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

        private void updateItem_search_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_search_click");
			
            string epc = textBox3.Text;
            if (epc != "")
            {
            	//在内存数组中根据epc找到指定的item
                ItemMain find = imList.Where(i => i.EPC == epc).FirstOrDefault();
				if (null == find)
				{
					Log.WriteLog(LogType.Trace, "can not find item with epc["+epc+"]");
					return;
				}

				//返回item在数组中的下标
                int index = imList.IndexOf(find);
				if (index != -1 )
				{
					Log.WriteLog(LogType.Trace, "success to find item["+find.itemID+"] with ecp["+epc+"], its array index is:"+index+"");
					
                	dgvItem.Rows[index].Selected = true;
                	//dataGridView2.SelectedRows.Clear();
				}
				else
				{
					Log.WriteLog(LogType.Error, "can not find item["+find.itemID+"] array index with ecp["+epc+"]");
				}

				return;
            }
        }

		//当点解dgv控件时，触发该函数进行处理
        private void updateItem_dgvItem_SelectionChanged(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_dgvItem_SelectionChanged");
			
            if (dgvItem.SelectedRows.Count >= 1)
            { 
                using (DataGridViewRow item = this.dgvItem.SelectedRows[0])
                {	
  
					//根据被选中的控件获得item在内存的数据
					int iItemIdx = item.Index;
                    ItemMain itemi = new ItemMain();
                    itemi = imList[iItemIdx];

					//提取指定信息
                    string itemID = itemi.itemID.ToString();
					string sEpc = itemi.EPC;
					//通过控件保存住item信息，供后面使用
                    oldEPC = sEpc;
                    //label5.Text = itemID;
					giItemId = Int32.Parse(itemID);
                    tbEpc.Text = sEpc;

					//修改store下拉框当前值
                    int sIndex = listS.IndexOf(listS.Where(u => u.StoreID == itemi.StoreID).FirstOrDefault());
                    cbStore.SelectedIndex = sIndex;

					//修改barcode下拉框当前值
                    int iBarcodeIdx = listBar.IndexOf(listBar.Where(v =>v.BarcodeNumber ==  itemi.BarcodeNumber).FirstOrDefault());
					cbBarcode.SelectedIndex = iBarcodeIdx;
					
					Log.WriteLog(LogType.Trace, "success to printf item["+itemID+"] with barcode["+  itemi.BarcodeID+"] in store["+itemi.StoreID+"] info into controls ");
	
                }
            }
            else
            {
				Log.WriteLog(LogType.Error, "error to update item info into controller.");
				return;
            }
        }

        private void updateItem_store_SelectedIdxChg(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_store_SelectedIdxChg");
			lConnectMsg.Text= " ";
			lStoreMsg.Text = " ";
			
            try
            {
            	if (cbStore.SelectedIndex > -1)
				{
					

					LTS.Store stStore = listS[cbStore.SelectedIndex];
					LTS.Settings set = DAT.DataAccess.GetSettings().Where(y => y.StoreID == stStore.StoreID && y.SettingsSelect == true).FirstOrDefault();

					//在指定的store下进行扫描，并返回扫到的epc
                	if (set == null)
	                {
	                	Log.WriteLog(LogType.Warning, "warning:there is not settings available in store["+stStore.StoreID+"]");
						
	                    lStoreMsg.Text = ("the matchine["+stStore.StoreName+"] is not band any settings, please change another matchine. ");
	                }				
            	}

            }
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "error to change store index, the error msg is " + ex.Message + "");
            }
            
        }
		

        private void updateItem_barcode_SelectedIdxChg(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_barcode_SelectedIdxChg");
			lConnectMsg.Text = " ";
			lBarcodeMsg.Text = " ";

            try
            {
				if (cbBarcode.SelectedIndex > -1)
				{	
					
				
					int iBarcodeIdx = cbBarcode.SelectedIndex;
					LTS.Barcode stBarcode =  listBar[iBarcodeIdx];
	                int iBarcodeId =stBarcode.BarcodeID;			

	                LTS.Product stProduct = DAT.DataAccess.GetProduct().Where(i => i.BarcodeID == iBarcodeId).FirstOrDefault();
	                if (null == stProduct)
	                {
	                    Log.WriteLog(LogType.Trace, "the barcode[" + iBarcodeId + "] does not band any product yet.");

	                    lBarcodeMsg.Text = "the barcode["+stBarcode.BarcodeNumber+"] is not band any product yet, please select another barcode";

						return;
	                }

					Log.WriteLog(LogType.Trace, "the barcode["+iBarcodeId+"] is band with product["+stProduct.ProductID+"]");
	                return;
				}
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "error to change barcode index, the error msg is " + ex.Message + "");
            }   

            return;
        }
		

        private void updateItem_update_click(object sender, EventArgs e)
        {
			int iItemId, iStortId, iBarcodeId;
			int iStortIdx, iBarcodeIdx;

		
			label4.Visible = false;
			label7.Visible = false;
			iItemId = giItemId;
			
        	Log.WriteLog(LogType.Trace, "come in updateItem_update_click");
			
			
			//判断epc合法性
			if (tbEpc.Text == "")
			{
				label4.Text = "Please enter the RFID Tag!";
				label4.Visible = true;
			}

			iStortIdx = cbStore.SelectedIndex;
			iBarcodeIdx = cbBarcode.SelectedIndex;
			//判断store和barcode的合法性
			if (iStortIdx == -1 || iBarcodeIdx == -1)
			{
				Log.WriteLog(LogType.Warning, "the store or the barcode has not change yet");
				MessageBox.Show("the store or the barcode has not change yet, please change them.");
				label7.Visible = true;

				return;
			}
				
			iStortId = listS[iStortIdx].StoreID;
			iBarcodeId = listBar[iBarcodeIdx].BarcodeID;
							
			
			try
			{
				//判断barcode是否绑定了product
				LTS.Product stProduct = new LTS.Product();
				stProduct = DAT.DataAccess.GetProduct().Where(f => f.BarcodeID == iBarcodeId).FirstOrDefault();
				if (null == stProduct)
				{
					Log.WriteLog(LogType.Warning, "the barcode["+iBarcodeId+"] has not band with product.");
					MessageBox.Show("the barcode["+iBarcodeId+"] has not band with product, please change another barcode.");
				
					return;
				}
				Log.WriteLog(LogType.Trace, "success to get product["+stProduct.ProductID+"] which band with barcode["+iBarcodeId+"]");

				//判断epc是否被使用
				if (tbEpc.Text != oldEPC)
				{
					LTS.Item stTmpItem = DAT.DataAccess.GetItem().Where(i => i.TagEPC == tbEpc.Text).FirstOrDefault();
					if (stTmpItem != null)
					{
						Log.WriteLog(LogType.Warning, "the ecp["+tbEpc.Text+"] already been use by item["+stTmpItem.ItemID+"].Please enter a different one.");
						
	                    label4.Text = "ecp["+tbEpc.Text+"] already been use! Please enter a different one.";
						label4.Visible = true;
						return;
					}
				}
						
				//判断item是否存在
	            LTS.Item stItem = DAT.DataAccess.GetItem().Where(d => d.ItemID == iItemId).FirstOrDefault();
				if (null == stItem)
				{
					Log.WriteLog(LogType.Error, "error to get item["+iItemId+"] from database");
	                MessageBox.Show("error to get item[" + iItemId + "] from database");
					return;
				}
				Log.WriteLog(LogType.Trace, "success to get item["+iItemId+"] from database");
			
			

				//更新item信息
				stItem.ProductID = stProduct.ProductID;
				stItem.StoreID = iStortId;stItem.StoreID = iStortId;
				
				if (tbEpc.Text != oldEPC)
				{
					stItem.TagEPC = tbEpc.Text;
				}


				//信息保存到数据库
				if (DAT.DataAccess.UpdateItem(stItem))
				{
					Log.WriteLog(LogType.Trace, "success to change item["+iItemId+"] ecp from["+oldEPC+"]into["+tbEpc.Text +"] witch band product with barcode["+iBarcodeId+"] in store["+iStortId+"]");
					
					MessageBox.Show("Item has been updated!");
					((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
				}
				else
				{
					Log.WriteLog(LogType.Trace, "error to change item["+iItemId+"] ecp from["+oldEPC+"]into["+tbEpc.Text +"] witch band product with barcode["+iBarcodeId+"] in store["+iStortId+"]");
					MessageBox.Show("error to update item info!");
				}

			}
			catch (Exception ex)
			{
            	Log.WriteLog(LogType.Error, "there is something wrong during to update item. the error msg is "+ex.Message+"");
				
                MessageBox.Show("there is something wrong during to update item!");
                return ;
            }
        }




        bool updateItem_connect(LTS.Settings se)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_connect");
	        try
			{
            	lConnectMsg.Text = "Connecting...";


	            int index = cbStore.SelectedIndex;
	            int storeID = listS[index].StoreID;

	            LTS.Settings set = se;

	            sm = null;
	            sm = new SettingsMain();
	            impinjrev.Clear();
	            sm.SettingsID = set.SettingsID;
	            sm.SettingsName = set.SettingsName;
	            sm.SettingsSelect = set.SettingsSelect;
	            sm.StoreID = set.StoreID;

	            LTS.Store store = DAT.DataAccess.GetStore().Where(i => i.StoreID == sm.StoreID).FirstOrDefault();
				if (null == store)
				{
					Log.WriteLog(LogType.Error, "error to get store with id["+set.StoreID+"]");
					return false;
				}
	            sm.StoreLocation = store.StoreLocation;
	            sm.StoreName = store.StoreName;

				Log.WriteLog(LogType.Trace, "success to get settings["+sm.SettingsID+"] witch in store["+set.StoreID+"] info:settingsName["+set.SettingsName+"], "+
									"select flag["+set.SettingsSelect+"], the storeName["+store.StoreName+"] and storeLocation["+store.StoreLocation+"]");
				

            	List<LTS.Reader> readers = new List<LTS.Reader>();
            	readers = DAT.DataAccess.GetReader().Where(j => j.SettingsID == sm.SettingsID).ToList();
				if (null == readers)
				{
					Log.WriteLog(LogType.Error, "error to get readers in settings["+sm.SettingsID+"]");
					return false;
				}
				
            	for (int j = 0; j < readers.Count; j++)
	            {
	                ReaderMain rm = new ReaderMain();
	                rm.ReaderID = readers[j].ReaderID;
	                rm.IPaddress = readers[j].IPaddress;
	                rm.NumAntennas = readers[j].NumAntennas;
	                rm.antennas = DAT.DataAccess.GetAntenna().Where(q => q.ReaderID == rm.ReaderID).ToList();

	                sm.Readers.Add(rm);

	            }
				
            	bool checks = true;

				Log.WriteLog(LogType.Trace, "success go get "+readers.Count+" readers with in settings["+sm.SettingsID+"] into memery");Log.WriteLog(LogType.Trace, "success go get "+readers.Count+" readers with in settings["+sm.SettingsID+"] into memery");
			
				//根据settings上的读写器配置，进行读写器连接操作
            	for (int x = 0; x < sm.Readers.Count; x++)
	            {
	            	//针对每一个reader配置生成一个reader解决方案节点
	                ImpinjRevolution ir = new ImpinjRevolution();
	                ir.ReaderScanMode = ScanMode.ScanItem;
	                ir.HostName = sm.Readers[x].IPaddress;
	                ir.Antennas = sm.Readers[x].antennas;

	                //ir.TagRead += ir_TagRead;

					Log.WriteLog(LogType.Trace, "goto connect to reader with ip["+ir.HostName+"]");
					//连接到指定的读写器上
	                if (!ir.ir_connectReader())
	                {
						Log.WriteLog(LogType.Error, "error to connect to reader["+ir.HostName+"]");
					}

	                impinjrev.Add(ir);
	                if (!ir.isConnected)
	                {
	                    if (checks == true)
	                    {
	                    	Log.WriteLog(LogType.Trace, "goto set the check flag into false status.");
	                        checks = false;
	                    }

	                }
	            }

				Log.WriteLog(LogType.Trace, "after connect to all the readers");
            	if (checks == true)
	            {
	                lConnectMsg.Text = "Connected";

					//启动定时器,定时器超时后，执行定时器超时函数
	                timer.Start();

					//遍历读写器数组，为他们注册委托事件，并启动读写器
	                impinjrev.ForEach(imp =>
	                {
                        imp.dReadHandler += updateItem_ir_tagRead;
	                    imp.ir_startRead();
	                });


					Log.WriteLog(LogType.Trace, "success to start all readers");
	                ((Form1)this.Parent.Parent.Parent.Parent).scan = true;
	                lConnectMsg.Text = "Reading...";
	                


	            }
            	else
	            {
	                lConnectMsg.Text = "Not Connected!";
	                timer.Stop();
	                timer.Elapsed -= updateItem_timer_elapsed;
	                time = 0;
	                for (int i = 0; i < impinjrev.Count; i++)
	                {
	                    impinjrev[i].ir_stopRead();
	                    impinjrev[i].ir_disconnect();

	                }
	                updateItem_enableOrDisable(true);
	                ((Form1)this.Parent.Parent.Parent.Parent).scan = false;
	            }
            	return true;

        	}
			catch (Exception ex)
			{
            	Log.WriteLog(LogType.Error, "there is something wrong during connect to readers. the error msg is "+ex.Message+"");
				
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
                return true;
            }

		}
		

        public void updateItem_enableOrDisable(bool what)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_enableOrDisable");
			
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (what)
                {
                    
                    cbStore.Enabled = true;
                    bBack.Enabled = true;
                    bUpdate.Enabled = true;
                    addStore.Enabled = true;
                    dgvItem.Enabled = true;
                    time = 0;
                }
                else
                {
                    
                    cbStore.Enabled = false;
                    bBack.Enabled = false;
                    bUpdate.Enabled = false;
                    addStore.Enabled = false;
                    dgvItem.Enabled = false;
                }
            }));
        }

		/*在指定的store里面扫描epc，并把epc返回*/
        private void updateItem_rfid_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_rfid_click");
			lConnectMsg.Text = " ";
			label4.Visible = false;
            try
            {
                time = 0;
                lblTimer.Text = time.ToString();
                timer = new System.Timers.Timer();
                timer.Elapsed += updateItem_timer_elapsed;
                timer.Interval = 1000;
                updateItem_enableOrDisable(false);
                epc = "";
                int iStore = cbStore.SelectedIndex;
                LTS.Store s = listS[iStore];

                LTS.Settings set = DAT.DataAccess.GetSettings().Where(y => y.StoreID == s.StoreID && y.SettingsSelect == true).FirstOrDefault();

				//在指定的store下进行扫描，并返回扫到的epc
                if (set != null)
                {
                	Log.WriteLog(LogType.Trace, "goto connect reader using settings["+set.SettingsID+"] configuration in store["+s.StoreID+"]");
					
                    updateItem_connect(set);
                }
                else
                {
                	Log.WriteLog(LogType.Warning, "warning:there is not settings available in store["+s.StoreID+"]");
					
                    lStoreMsg.Text = ("Settings not found!");
                    updateItem_enableOrDisable(true);
                }
            }
            catch (Exception exx)
            {
            	Log.WriteLog(LogType.Error, "error to get epc from specify store");
				
                lStoreMsg.Text = ("error to get epc from specify store");
                updateItem_enableOrDisable(true);
            }
        }

        //read tags
        bool updateItem_ir_tagRead(TagInfo tag, EventArgs e, Queue<TagInfo> stTagList, ref  Mutex stMutex)
        {
            Log.WriteLog(LogType.Trace, "come in updateItem_ir_tagRead");
            if (tag != null && epc == "")
            {
                string Tag = tag.sEpc;
                epc = Tag;
            }

            return true;
        }

       	void updateItem_ir_stop()
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_ir_stop");
            try
            {
            	if (impinjrev != null)
	            {
	            	//停止所有读写器
	                for (int i = 0; i < impinjrev.Count; i++)
	                {
	                    impinjrev[i].ir_stopRead();
	                    impinjrev[i].ir_disconnect();

	                }

					//显示提示信息
	                if (lConnectMsg.InvokeRequired)
	                {
	                    lConnectMsg.Invoke(new MethodInvoker(delegate () {
	                        lConnectMsg.Text = "Disconnected!";
	                    }));

	                }

					updateItem_enableOrDisable(true);
	                ((Form1)this.Parent.Parent.Parent.Parent).scan = false;
	            }
                Log.WriteLog(LogType.Trace, "success to stop all the readers and disconnect from them");
            }
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Trace, "error to stop all the readers and disconnect from them, the error msg is "+ex.Message+".");
                MessageBox.Show("error to stop all the readers and disconnect from them");
            }
        }

	   	//time超时处理函数
        void updateItem_timer_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        	try
            {
            	if (time < 60 && epc == "")
	            {
					//在指定的时间里没有找到epc，只需要更新提示时间即可
	                time++;
	                if (lblTimer.InvokeRequired)
	                {
	                    lblTimer.Invoke(new MethodInvoker(delegate ()
						{
	                        lblTimer.Text = time.ToString();
	                    }));
	                }
	            }
            	else
	            {
	            	//定时器超时或找到epc，则停止定时器
	                timer.Stop();
	                timer.Elapsed -= updateItem_timer_elapsed;
	                if (lblTimer.InvokeRequired)
	                {
	                    lblTimer.Invoke(new MethodInvoker(delegate () {
	                        lblTimer.Text = time.ToString();
	                        tbEpc.Text = epc;
	                    }));

	                }

	                updateItem_ir_stop();
	                time = 0;

					Log.WriteLog(LogType.Trace, "success to stop timer, the time = "+time+" and the epc is ["+epc+"]");
	            }
        	}
			catch (Exception ex)
			{
            	Log.WriteLog(LogType.Error, "error to process the time out handler.");
				
                MessageBox.Show("error to process the time out handler.");
            }

        }

        private void updateItem_rfidSearch_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateItem_rfidSearch_click");
			updateItem_rfid_click(sender, e);
        }


    }
}
