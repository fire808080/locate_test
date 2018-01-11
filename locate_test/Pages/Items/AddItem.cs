using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.DataClasses;
using ssms.Util;

namespace ssms.Pages.Items
{
    public partial class AddStock : UserControl
    {
        //Timer ScanTimer = new Timer();
        System.Timers.Timer timer;

		//用于保存从数据库读出来的记录
        List<LTS.Brand> listB;
        List<LTS.Category> listC;
        List<LTS.Store> listS;
        List<LTS.Barcode> listBar;
        SettingsMain sm = new SettingsMain();
        List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();
        string epc = "";
        int time = 0;
        

        public AddStock()
        {
        	Log.WriteLog(LogType.Trace, "come in AddStock");
			
            InitializeComponent();
        }

        //to change the content of the small panel
        public void ChangeView<T>() where T : Control, new()
        {
        	Log.WriteLog(LogType.Trace, "come in ChangeView");
            try
            {
				//清空panel控件
                panel1.Controls.Clear();

				//生成指定页面的对象
                T find = new T();

				//将指定页面加载到panel控件中
                find.Parent = panel1;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch
            {

            }
        }


        private void addItem_addStore_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_addStore_click");
			
            bAdd.Enabled = false;
            bRfid.Enabled = false;
            
            cbStore.Enabled = false;
            cbBarcode.Enabled = false;
            ChangeView<Store.AddStoreSmall>();
        }

        //after a store is added in the small panel you need to update the combobox
        public void addItem_updateStore()
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_updateStore");
        	//更新store下拉列表
            try
            {
                panel1.Controls.Clear();
                cbStore.DataSource = null;
                listS.Clear();
                listS = DAT.DataAccess.GetStore().ToList();
                List<string> S = new List<string>();

				Log.WriteLog(LogType.Trace, "success get "+listS.Count+"store records from datebase.");
				
                for (int x = 0; x < listS.Count; x++)
                {
                    S.Add(listS[x].StoreName);
					
					Log.WriteLog(LogType.Trace, "add store with name["+ listS[x].StoreName +"] into memery.");
                }
                cbStore.DataSource = S;

                bAdd.Enabled = true;
                bRfid.Enabled = true;

                cbStore.Enabled = true;
                cbBarcode.Enabled = true;
            }
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "error to update store name into comboBox");
				
                MessageBox.Show("error to update store name into comboBox");
            }
            
        }

        private void addItem_load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "addItem_load");
			
            try
            {
                //load store names into combo box from db
                listS = DAT.DataAccess.GetStore().ToList();
                List<string> S = new List<string>();

				Log.WriteLog(LogType.Trace, "success get "+listS.Count+"store records from datebase.");
	
                for (int x = 0; x < listS.Count; x++)
                {
                    S.Add(listS[x].StoreName);

					Log.WriteLog(LogType.Trace, "add store["+listS[x].StoreID+"] with name["+ listS[x].StoreName +"] into memery.");
                }
                cbStore.DataSource = S;


                //load barcode into combo box from db
                listBar = DAT.DataAccess.GetBarcode().ToList();
                List<string> Bar = new List<string>();

				Log.WriteLog(LogType.Trace, "success get "+listBar.Count+"barcode records from datebase.");

                for (int x = 0; x < listBar.Count; x++)
                {
                    Bar.Add(listBar[x].BarcodeNumber);

					Log.WriteLog(LogType.Trace, "add barcode["+listBar[x].BarcodeID+"] with number["+ listBar[x].BarcodeNumber +"] into memery.");
                }
                cbBarcode.DataSource = Bar;
            }
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "error to get store info or barcode info into page!");
				
                MessageBox.Show("error to get store info or barcode info into page!");
            }
            
        }

        private void addItem_back_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "addItem_back_click");
			
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

  		//添加一个item,（一个epc只能对应一个item）
        private void addItem_add_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "addItem_add_click");
			lStoreMsg.Visible = false;
			label16.Visible = false;
			lBarcodeMsg.Visible = false;
			lEpcMsg2.Visible = false;
			lEpcMsg1.Visible = false;
			
            try
            {

				//判断参数合法性
                int storeIndex = cbStore.SelectedIndex;
				int barcodeIndex = cbBarcode.SelectedIndex;

				
                if (storeIndex == -1)
                {
                    lStoreMsg.Visible = true;
					Log.WriteLog(LogType.Error, "the store is not select");
					
					return;
                }
				if (barcodeIndex == -1)
                {
                    label16.Visible = true;
					Log.WriteLog(LogType.Error, "the barcode is not select");
					return;
                }
				if (textBox2.Text == "")
				{
					lEpcMsg1.Visible = true;
					Log.WriteLog(LogType.Error, "the ecp string is null");
					return;
				}
								
				//判断barcode是否绑定了product
				int barcodeID = listBar[barcodeIndex].BarcodeID;
                LTS.Product p = DAT.DataAccess.GetProduct().Where(a => a.BarcodeID == barcodeID).FirstOrDefault();
				if (p == null)
				{
					lBarcodeMsg.Visible = true;
					Log.WriteLog(LogType.Error, "the barcode["+barcodeID+"] is not band any product");
					return;
				}
				Log.WriteLog(LogType.Trace, "the barcode["+barcodeID+"] is band with product["+p.ProductID+"]");


				//判断这个epc是否已经被使用，一个epc只能对应一个item
                LTS.Item stItem = DAT.DataAccess.GetItem().Where(b => b.TagEPC == textBox2.Text).FirstOrDefault(); 
				if (stItem != null)
				{
                    
                    lEpcMsg2.Text = "epc["+ textBox2.Text+"] alreasy be use! Please enter a different one.";

					Log.WriteLog(LogType.Trace, "the ecp["+textBox2.Text+"] has already exist, please enter a different one");

					lEpcMsg2.Visible = true;
					return;
                }


				//保存item信息
				LTS.Item stNewItem = new LTS.Item();
				if (stNewItem == null)
				{
					Log.WriteLog(LogType.Error, "Error to get new item memery");
					MessageBox.Show("error to get memery from system");
					return;
				}
				
                stNewItem.StoreID = listS[storeIndex].StoreID;
				stNewItem.TagEPC = textBox2.Text;
				stNewItem.ProductID = p.ProductID;
				stNewItem.ItemStatus = true;


								
				int returnedID = DAT.DataAccess.AddItem(stNewItem);
			   	if (returnedID == -1)
				{
					Log.WriteLog(LogType.Trace, "errir to add item with epc["+stNewItem.TagEPC+"] and produce["+stNewItem.ProductID+"] into store["+stNewItem.StoreID+"]");
					MessageBox.Show("Item was not added to the database!");
				}
			   	else
				{
					Log.WriteLog(LogType.Trace, "success to add item["+returnedID+"] with epc["+stNewItem.TagEPC+"] and produce["+stNewItem.ProductID+"] into store["+stNewItem.StoreID+"]");
					MessageBox.Show("Item was succesfully added to the database");
					((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
				}
   
				return;	                
            }
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "error to add item into database, the error msg is "+ex.Message+"");
				
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
           
        }

		/*当barcode改变时，用来实时显示该barcode的产品，厂家，类型信息。（一个barcode只能对应一个product）*/
        private void addItem_barcode_selectedIdxChg(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_barcode_selectedIdxChg");

			lBarcodeMsg.Visible = false;
            try
            {
	            cbBarcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
	            cbBarcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
	            cbBarcode.AutoCompleteSource = AutoCompleteSource.ListItems;
				
            	try
	            {
	            	/*获取barcode信息*/
	                int bIndex = cbBarcode.SelectedIndex;
	                int barID = listBar[bIndex].BarcodeID;
					
					Log.WriteLog(LogType.Trace, "the barcord["+barID+"] with index["+bIndex+"] is selected.");
					

					/*获取barcode对应的产品信息*/
	                LTS.Product p = new LTS.Product();
	                p = DAT.DataAccess.GetProduct().Where(f => f.BarcodeID == barID).FirstOrDefault();
					if (p == null)
					{
						Log.WriteLog(LogType.Warning, "there is not product band with barcode["+barID+"]");

						panel1.Controls.Clear();
	                    
	                    lBarcodeMsg.Parent = panel1;
	                    lBarcodeMsg.Dock = DockStyle.Fill;
	                    lBarcodeMsg.BringToFront();
						lBarcodeMsg.Visible = true;
						return;
					}
						
                    Log.WriteLog(LogType.Trace, "success get product[" + p.ProductID + "] witch bind with barcode[" + barID + "]");	
                    string pBarcode = cbBarcode.Text;
					
					/*获得产品的厂家id和类型id*/
                    string brand = DAT.DataAccess.GetBrand().Where(o => o.BrandID == p.BrandID).FirstOrDefault().BrandName;
					Log.WriteLog(LogType.Trace, "success get brand["+p.BrandID+"] witch named["+brand+"]");
					
                    string cat = DAT.DataAccess.GetCategory().Where(o => o.CategoryID == p.CategoryID).FirstOrDefault().CategoryName;
					Log.WriteLog(LogType.Trace, "success get category["+p.CategoryID+"] witch named["+cat+"]");


					/*显示barcode对应的产品详细信息*/
	                try
	                {
	                	Log.WriteLog(LogType.Trace, "goto show the barcode["+barID+"] beyond to product["+p.ProductID+"] in brand["+ p.BrandID+"] category["+p.CategoryID+"] detail info");
						
	                    panel1.Controls.Clear();
	                    Control find = new ShowProductDetails(pBarcode, p.ProductName, p.ProductDescription, brand, cat);
	                    find.Parent = panel1;
	                    find.Dock = DockStyle.Fill;
	                    find.BringToFront();
	                }
	                catch (Exception ex)
	                {
						Log.WriteLog(LogType.Trace, "error to show barcode["+barID+"] detail info");
						throw ex;
	                }     



	            }
            	catch(Exception ex)
	            {
					Log.WriteLog(LogType.Trace, "error to get barcode detail info");
					throw ex;
	            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        private void addItem_store_SelectedIdxChg(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_store_SelectedIdxChg");

			lStoreMsg.Visible = false;
			
            try
            {
                cbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cbStore.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbStore.AutoCompleteSource = AutoCompleteSource.ListItems;

				int iStoreIdx = cbStore.SelectedIndex;
				int iStoreId = listS[iStoreIdx].StoreID;

				Log.WriteLog(LogType.Trace, "success to change into store["+iStoreId+"]");
            }
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "error to change store, the error msg is "+ex.Message+"");
			
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

        private void addItem_rfid_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_rfid_click");

            lStoreMsg.Visible = false;

            try
            {
                try
	            {
                    time = 0;
                    lblTimer.Text = time.ToString();
					
                    timer = new System.Timers.Timer();
					//注册时间超时后需要执行的事件
                    timer.Elapsed += addItem_timer_elapsed;
                    timer.Interval = 1000;

					//屏蔽一些控件的可用性
                    addItem_enableOrDisable(false);

					
                    epc = "";
                    int iStore = cbStore.SelectedIndex;
                    LTS.Store s = listS[iStore];

					//读取store下生效的settings配置
	                LTS.Settings set = DAT.DataAccess.GetSettings().Where(y => y.StoreID == s.StoreID && y.SettingsSelect == true).FirstOrDefault();
	                if (set != null)
	                {
	                	Log.WriteLog(LogType.Trace, "goto connect reader with setting["+set.SettingsID+"] in store["+s.StoreID +"]");
	                    addItem_connect(set);
	                }
	                else
	                {
	                    //lblConnect.Text = ("Settings not found!");
						lStoreMsg.Visible = true;

						Log.WriteLog(LogType.Error, "can not get any settings from database with in store["+s.StoreID+"]");
						
	                    addItem_enableOrDisable(true);

	                }
	            }
            	catch (Exception exx)
            	{
					Log.WriteLog(LogType.Error, "error to get settings info with store");
	                //lblConnect.Text = ("Store not selected!");
	                lStoreMsg.Visible = true;
	                addItem_enableOrDisable(true);

                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "error to connect to reader in store");
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }

           
        }

        bool addItem_connect(LTS.Settings se)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_connect");
			
            try
            {
                lblConnect.Text = "Connecting...";
                int index = cbStore.SelectedIndex;
                int storeID = listS[index].StoreID;

            	LTS.Settings set = se;

				/*从数据库中读取setting的配置*/
            	sm = null;
            	sm = new SettingsMain();
            	impinjrev.Clear();
            	sm.SettingsID = set.SettingsID;
            	sm.SettingsName = set.SettingsName;
            	sm.SettingsSelect = set.SettingsSelect;
            	sm.StoreID = set.StoreID;

            	LTS.Store store = DAT.DataAccess.GetStore().Where(i => i.StoreID == sm.StoreID).FirstOrDefault();
            	sm.StoreLocation = store.StoreLocation;
            	sm.StoreName = store.StoreName;

				Log.WriteLog(LogType.Trace, "success to get settings["+sm.SettingsID+"] witch in store["+set.StoreID+"] info:settingsName["+set.SettingsName+"], "+
					"select flag["+set.SettingsSelect+"], the storeName["+store.StoreName+"] and storeLocation["+store.StoreLocation+"]");
				
				/*从数据库中读取reader的配置*/
            	List<LTS.Reader> readers = new List<LTS.Reader>();
            	readers = DAT.DataAccess.GetReader().Where(j => j.SettingsID == sm.SettingsID).ToList();
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

				Log.WriteLog(LogType.Trace, "success go get "+readers.Count+" readers with in settings["+sm.SettingsID+"] into memery");

				//根据settings上的读写器配置，进行读写器连接操作
            	for (int x = 0; x < sm.Readers.Count; x++)
	            {
	            	//针对每一个reader配置生成一个reader解决方案节点
	                ImpinjRevolution ir = new ImpinjRevolution();
	                ir.ReaderScanMode = ScanMode.ScanItem;
	                ir.HostName = sm.Readers[x].IPaddress;
	                ir.Antennas = sm.Readers[x].antennas;
	                //ir.TagRead += ir_TagRead;  //注册委托函数

					Log.WriteLog(LogType.Trace, "goto connect to reader with ip["+ir.HostName+"]");
					//连接到指定的读写器上
	                if(!ir.ir_connectReader())
	                {
						Log.WriteLog(LogType.Trace, "error to connect to reader["+ir.HostName+"]");
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
	            	Log.WriteLog(LogType.Trace, "all the readers are connected, so goto check them.");
					
	                lblConnect.Text = "Connected.";

					//启动定时器,定时器超时后，执行定时器超时函数
	                timer.Start();

					//遍历读写器数组，为他们注册委托事件，并启动读写器
	                impinjrev.ForEach(imp =>
	                {
                        imp.dReadHandler += addItem_ir_tagRead;
	                    imp.ir_startRead();
	                });

					Log.WriteLog(LogType.Trace, "success to start all readers");
					
	                ((Form1)this.Parent.Parent.Parent.Parent).scan = true;
	                lblConnect.Text = "Reading...";

	                lblTimer.Text = time.ToString();
	            }
            	else
	            {
	                lblConnect.Text = "Not Connected!";
	                timer.Stop();
	                timer.Elapsed -= addItem_timer_elapsed;
	                time = 0;
	                for (int i = 0; i < impinjrev.Count; i++)
	                {
	                    impinjrev[i].ir_stopRead();
	                    impinjrev[i].ir_disconnect();

	                }
                    addItem_enableOrDisable(true);
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

        //read tags
        bool addItem_ir_tagRead(TagInfo tag, EventArgs e, Queue<TagInfo> stTagList, ref  Mutex stMutex)
        {
            if (tag != null && epc=="")
            {
                string Tag = tag.sEpc;

                epc = Tag;             
            }

            return true;
        }

		//控制控件的可用性
        public void addItem_enableOrDisable(bool bEnable)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_enableOrDisable");
            try
			{
				//因为跨线程调用，所以使用委托
				this.Invoke(new MethodInvoker(delegate ()
				{
					if (bEnable)
					{
						cbStore.Enabled = true;
						bBack.Enabled = true;
						bAdd.Enabled = true;
						bAddStore.Enabled = true;

						time = 0;

						Log.WriteLog(LogType.Trace, "success to enable the controllers.");
						
					}
					else
					{
						cbStore.Enabled = false;
						bBack.Enabled = false;
						bAdd.Enabled = false;
						bAddStore.Enabled = false;

						Log.WriteLog(LogType.Trace, "success to disable the controllers.");
					}
				}));

			}
            catch (Exception ex)
            {
            	Log.WriteLog(LogType.Error, "error to enable or disable the controllers, the error msg is "+ex.Message+"");
				
                MessageBox.Show("error to enable or disable the controllers");
            }
            
        }

		//定时器线程会调用该函数
       	void addItem_ir_stop()
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_ir_stop");
            try
            {
                if (impinjrev != null)
                {
                    for (int i = 0; i < impinjrev.Count; i++)
                    {
                        impinjrev[i].ir_stopRead();
                        impinjrev[i].ir_disconnect();

                    }
                    if (lblConnect.InvokeRequired)
                    {
                        lblConnect.Invoke(new MethodInvoker(delegate () {
                            lblConnect.Text = "Disconnected!";
                        }));

                    }

                    addItem_enableOrDisable(true);
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

		//定时器线程会执行该函数
        void addItem_timer_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addItem_timer_elapsed");
            try
            {
                if (time < 60 && epc == "")
                {

                	//更新超时次数
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
                	//停止定时器
                    timer.Stop();
                    timer.Elapsed -= addItem_timer_elapsed;
                    if (lblTimer.InvokeRequired)
                    {
                        lblTimer.Invoke(new MethodInvoker(delegate ()
                        {
                            lblTimer.Text = time.ToString();
                            textBox2.Text = epc;
                        }));

                    }

					
					
                    addItem_ir_stop();
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


        }

}
