using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

using ssms.Pages.Settings;
using ssms.DataClasses;
using ssms.Util;
using ssms;




namespace ssms.Pages
{
    public partial class UpdateSettings : UserControl
    {
        List<AntennaConfig> AntennaList = new List<AntennaConfig>();
        List<Reader> reader = new List<Reader>();
		List<LTS.Store> lStore = new List<LTS.Store>();
		List<LTS.Settings> lSet = new List<LTS.Settings>();
		int giStoreIdx, giSettingIdx;
		int giStoreId, giSettingId;
		int giReaderIdx, giReaderId;


		/*获取指定store和setting的settingID*/
		private int UpdateSettings_GetSettingsID()
		{
            int iSettingsID;

			Log.WriteLog(LogType.Trace, "come in UpdateSettings_GetSettingsID");

            string sSql = "SELECT Settings.SettingsID FROM Settings " +
                "JOIN Store ON Settings.StoreID = Store.StoreID " +
                "WHERE Store.StoreName = '" + comboBoxStore.Text + "' and Settings.SettingsName = '" + comboBoxSettings.Text + "';";

			try
			{
				DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
                DataTable stDt = stDs.Tables[0];
                if (stDt.Rows.Count == 1)
                {
                    iSettingsID = int.Parse(stDt.Rows[0]["SettingsID"].ToString());
                    Log.WriteLog(LogType.Trace, "success to get settingsID[" + iSettingsID + "] with store[" + comboBoxStore.Text + "] and settings[" + comboBoxSettings.Text + "]");
                    return iSettingsID;
                }
                else
                {
                    Log.WriteLog(LogType.Error, "error:there are more than 1 setting id record with store[" + comboBoxStore.Text + "] and settings[" + comboBoxSettings.Text + "], is impossible");
                    return -1;
                }
				
			}
			catch(Exception ex)
			{
				return -1;
			}
		}

				/*将内存配置设置到数据库*/
		private bool UpdateSettings_CreateReadersSql(ref ArrayList aSqlList)
		{
            Log.WriteLog(LogType.Trace, "come in UpdateSettings_CreateReadersSql");
            if (UpdateSettings_GetSettingsID() < 0)
            {
                Log.WriteLog(LogType.Error, "error to call UpdateSettings_GetSettingsID");
                return false;
            }
			
			/*遍历reader数组*/
			for (int idx = 0; idx < reader.Count; idx ++)
			{
				
			}
            return true;
		}
		
		private bool UpdateSettings_GetStores()
		{
		
			Log.WriteLog(LogType.Trace, "come in UpdateSettings_GetStores");
		
			string sSql = "SELECT Store.StoreName FROM Store;";
			
			try
			{
				DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
				comboBoxStore .DataSource = stDs.Tables[0];
				comboBoxStore.DisplayMember = "StoreName";
				comboBoxStore.SelectedIndex = 0;

				
							
				Log.WriteLog(LogType.Trace, "success to get store names");
				return true;
			}
			catch(Exception ex)
			{
				Log.WriteLog(LogType.Trace, "error to get store names");
				return false;
			}				
		}
				
		/*获取要删除的reader id和antenna id*/
		private DataSet updateSettings_getDelReader()
		{
			Log.WriteLog(LogType.Trace, "come in updateSettings_getDelReader");

            string sSql = "SELECT Antenna.AntennaID, Reader.ReaderID FROM Antenna " +
                "JOIN Reader ON Antenna.ReaderID = Reader.ReaderID " +
                "JOIN Settings ON Reader.SettingsID = Settings.SettingsID " +
                "JOIN Store ON Settings.StoreID = Store.StoreID " +
                "WHERE Store.StoreID = '" + giStoreId + "' and Settings.SettingsID = '" + giSettingId + "';";

			try
			{
				DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
				return stDs;
			}
			catch(Exception ex)
			{
				return null;
			}
		}

        /*组装删除指定store和setting下的所有reader和antenna语句*/
        private bool updateSettings_encodeSqlForDel(ref ArrayList lSql)
        {
            Log.WriteLog(LogType.Trace, "come in updateSettings_encodeSqlForDel");

			//删除指定settings下所有reader和antenna的记录
            DataSet stDs = updateSettings_getDelReader();
            if (null == stDs)
            {
                Log.WriteLog(LogType.Error, "error to call updateSettings_getDelReader");
                return false;
            }

			//根据查询记录组装删除语句
            DataTable stDt = stDs.Tables[0];
            DataRow stDr;
            if (stDt.Rows.Count > 0)
            {
            	List<string> lReaderId = new List<string>();
				
                /*建立删除antenna的sql语句*/
                for (int idx = 0; idx < stDt.Rows.Count; idx++)
                {
                    stDr = stDt.Rows[idx];
                    lSql.Add("DELETE FROM Antenna WHERE Antenna.AntennaID = " + stDr["AntennaID"] + ";");

					lReaderId.Add(stDr["ReaderID"].ToString());
					Log.WriteLog(LogType.Trace, "save reader id["+stDr["ReaderID"]+"] into duplicate queue.");
                }

				//去掉重复readerid
				lReaderId = lReaderId.Distinct().ToList();
				
                /*建立删除reader的sql语句*/
                for (int idx = 0; idx < lReaderId.Count; idx++)
                {
					lSql.Add("DELETE FROM Reader WHERE ReaderID = " + lReaderId[idx]+ ";");  
                }

            }
            else
            {
                Log.WriteLog(LogType.Trace, "there is not reader and antenna config under store[" + giStoreId + "] setting[" + giSettingId + "]");
            }

            Log.WriteLog(LogType.Trace, "success to create delete sql string under store[" + giStoreId + "] setting[" + giSettingId + "] ");

			/*测试代码，数据所有sql语句*/
			#if true
			for (int idx = 0; idx <  lSql.Count; idx++)
			{
				Log.WriteLog(LogType.Trace, "the reader delete sql["+idx+"] is:"+lSql[idx]+"");
			}
			#endif
			
            return true;
        }


			



		
		




		



		
         		
		

		
		private void comboBoxSettings_selectIdxChg(object sender, EventArgs e)  
		{			
			Log.WriteLog(LogType.Trace, "come in comboBoxSettings_selectIdxChg");

            if (comboBoxSettings.SelectedIndex > -1)
            {
            	giSettingIdx = comboBoxSettings.SelectedIndex;
				giSettingId = lSet[giSettingIdx].SettingsID;

				Log.WriteLog(LogType.Trace, "goto load reader info for settings["+giSettingId+"]");
				
				/*根据store值、setting值加载reader的值*/
				if (!updateSettings_getReaderInfo())
				{
					Log.WriteLog(LogType.Error, "error to call updateSettings_getReaderInfo");
					return;
				}
            }
			
            return;
        }

		//修改了store下拉框
        private void comboBoxStore_selectedIdxChg(object sender, EventArgs e)  
        {			
			Log.WriteLog(LogType.Trace, "come in comboBoxStore_selectedIdxChg");

            if (comboBoxStore.SelectedIndex > -1)
            {
            	giStoreIdx = comboBoxStore.SelectedIndex;
				giStoreId = lStore[giStoreIdx].StoreID;

                Log.WriteLog(LogType.Trace, "goto load the settings info for store[" + giStoreId + "].");
			
            	/*根据store获得setting值*/
            	if (!updateSettings_getSettings())
            	{
					Log.WriteLog(LogType.Error, "error to call updateSettings_getSettings");
					return;
				}

            }

			
            return;
        } 

		//处理datagridview的行改变事件
		private void dgvReaders_RowEnter(object sender, DataGridViewCellEventArgs e)  
		{  
			Log.WriteLog(LogType.Trace, "come in dgvReaders_RowEnter");

			if (dgvReaders.CurrentRow != null)
			{
			    giReaderIdx = e.RowIndex;//获取当前行  	             
			    giReaderId = reader[giReaderIdx].ReaderID;

				Log.WriteLog(LogType.Trace, "change to config reader["+giReaderId+"]");
			}

			return;
		}  

		
		/*将指定reader下的所有天线信息保存到内存中*/
		private bool updateSettings_saveAntennaInfo(ref Reader stReader)
		{
			int iReaderId = stReader.ReaderID;
			
			Log.WriteLog(LogType.Trace, "come in updateSettings_saveAntennaInfo");

			try
			{
	        	Log.WriteLog(LogType.Trace, "goto get reader[" + iReaderId + "] all antenas info.");
				
	            string sAntSql = "select AntennaID, TxPower, RxPower, AntennaNumber, ReaderID from Antenna where ReaderID = " + iReaderId +";";
	            DataSet stAntDs = SqlAccess.GetDataSet(sAntSql);
	            DataTable stAntDt = stAntDs.Tables[0];

				if (stAntDt.Rows.Count > 0)
				{
					Log.WriteLog(LogType.Trace, "there are "+stAntDt.Rows.Count+" antenna in reader["+iReaderId+"] ");
	                for (int iARowIdx = 0; iARowIdx < stAntDt.Rows.Count; iARowIdx++)
	                {
	                	StringBuilder sLog = new StringBuilder(); 
	                	antenna stAntenna = new antenna();
						
	                    DataRow stAntDr = stAntDt.Rows[iARowIdx];
	                    
	                    stAntenna.rxPower = decimal.Parse(stAntDr["RxPower"].ToString());
	                    stAntenna.txPower = decimal.Parse(stAntDr["TxPower"].ToString());
	                    stAntenna.antennaNumber = int.Parse(stAntDr["AntennaNumber"].ToString());
	                    stAntenna.AntennaID = int.Parse(stAntDr["AntennaID"].ToString());
	                    stAntenna.ReaderID = int.Parse(stAntDr["ReaderID"].ToString());
	                    stReader.antenna.Add(stAntenna);

	                    sLog.Clear();
	                    sLog.AppendFormat("success to set antenna row[{0}] info into memery \r\n", iARowIdx);
	                    sLog.AppendFormat("the antenna info:id[{0}], txPower[{1}], rxPower[{2}], antennaNumber[{3}], readerID[{4}]",
	                        stAntDr["AntennaID"], stAntDr["TxPower"], stAntDr["RxPower"], stAntDr["AntennaNumber"], stAntDr["ReaderID"]);
						Log.WriteLog(LogType.Trace, sLog);
	                }
				}
				else
				{
					Log.WriteLog(LogType.Trace, "there is not antenna record in reader[" + iReaderId   +"]");
				}
			}
			catch(Exception ex)
			{
				return false;
			}

			return true;
        }
		

		/*获取指定store和settings下所有reader的配置信息*/
		private bool updateSettings_getReaderInfo()
		{
            StringBuilder sLog = new StringBuilder(); 
			
            

			string sStoreName = comboBoxStore.Text;
			string sSettingName = comboBoxSettings.Text;
	
			Log.WriteLog(LogType.Trace, "come in updateSettings_getReaderInfo");

			/*清空上一次操作的数据*/
			reader.Clear();

			/*将reader和antenna数据从数据库对到内存中*/
			try
			{
				StringBuilder sSql = new StringBuilder(); ;
				sSql.AppendFormat("select Reader.ReaderID, Reader.IPaddress, Reader.SettingsID, Reader.NumAntennas from Reader ");				
				sSql.AppendFormat("JOIN Settings ON Settings.SettingsID = Reader.SettingsID ");
				sSql.AppendFormat("JOIN Store ON Settings.StoreID = Store.StoreID ");
				sSql.AppendFormat("WHERE Settings.SettingsID = '{0}' and Store.StoreID = '{1}'", giSettingId, giStoreId);
			
				Log.WriteLog(LogType.Trace, "goto get all reader in store["+giStoreId+"], setting[" +giSettingId+"]");
				DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
				DataTable stDt = stDs.Tables[0];

				/*添加reader数据到内存*/
				if (stDt.Rows.Count > 0)
				{
					Log.WriteLog(LogType.Trace, "there are " + stDt.Rows.Count +" reader in store["+giStoreId+"], setting["+giSettingId+"].");
				
                    for (int iRowIdx = 0; iRowIdx < stDt.Rows.Count; iRowIdx ++)
                    {
                    	Reader stReader = new Reader();
                        DataRow stDr = stDt.Rows[iRowIdx];

						stReader.ReaderID = int.Parse(stDr["ReaderID"].ToString());
                        stReader.IPaddress = stDr["IPaddress"].ToString();
                        stReader.SettingsID = int.Parse(stDr["SettingsID"].ToString());
						stReader.numAntennas = int.Parse(stDr["NumAntennas"].ToString());
						
                        /*添加reader下所有antenna信息到内存*/
						if (!updateSettings_saveAntennaInfo(ref stReader))
						{
							Log.WriteLog(LogType.Error, "error to save reader["+stReader.ReaderID+"] antenna info into menery");
							continue;
						}
											
                        /*添加reader信息到内存*/
                        reader.Add(stReader);

                        sLog.Clear();
                        sLog.AppendFormat("success to save reader["+stReader.ReaderID+"] info into memery \r\n");
                        sLog.AppendFormat("the reader info:id[{0}], readerIp[{1}], settingId[{2}]", stDr["ReaderID"], stDr["IPaddress"], stDr["SettingsID"]);
                        Log.WriteLog(LogType.Trace, sLog);

                    }
				}
				else
				{
					Log.WriteLog(LogType.Trace, "there are " + stDt.Rows.Count +" reader in store["+giStoreId+"], setting["+giSettingId+"].");
				}

				/*将reader数据通过控件显示出来*/
				dgvReaders.Rows.Clear();
                for(int x =0; x < reader.Count; x++)
                {
                    dgvReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                }	
			}
			catch(Exception ex)
			{
				return false;
			}
		

			return true;
		}
		

		/*获取一个store下的所有settings名字*/
		private bool updateSettings_getSettings()
		{
			Log.WriteLog(LogType.Trace, "come in updateSettings_getSettings");

			//清空原有内容
            comboBoxSettings.DataSource = null;

			if (dgvReaders.DataSource != null)
			{
				DataTable dt_tmp = (DataTable) dgvReaders.DataSource;
				dt_tmp.Rows.Clear();
				dgvReaders.DataSource = dt_tmp;
			}

			int iStoreIdx = giStoreIdx;
			int iStoreId = giStoreId;

			try
			{
	            lSet = DAT.DataAccess.GetSettings().Where(i=>i.StoreID == iStoreId).ToList();
				Log.WriteLog(LogType.Trace, "success to get ["+ lSet.Count +"]settings records for store["+iStoreId+"]");
				
				/*设置setting下拉框的值*/
				if (lSet.Count > 0)
				{
					List<string> S = new List<string>();
					
		            for (int x = 0; x < lSet.Count; x++)
		            {
		                S.Add(lSet[x].SettingsName);
		            }
					comboBoxSettings.DataSource = S;
					comboBoxSettings.SelectedIndex = 0;

					Log.WriteLog(LogType.Trace, "success to load settings info for store["+iStoreId+"].");
                    return true;
				}
				else
				{
					Log.WriteLog(LogType.Trace, "the store["+iStoreId+"] has not settings.");
                    return true;
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog(LogType.Error, "error to load settings info for store["+iStoreId+"], the error msg is ["+ex.Message.ToString()+"]");
                return false;
			}

		}
		
		/*加载update settings页面信息*/
		private void updateSettings_load(object sender, EventArgs e)
		{
			Log.WriteLog(LogType.Trace, "come in updateSettings_load");
		
            //从数据库读取store列表
            lStore = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

			//加载到页面
            for (int x = 0; x < lStore.Count; x++)
            {
                S.Add(lStore[x].StoreName);
            }
            comboBoxStore.DataSource = S;
			comboBoxStore.SelectedIndex = 0;

			Log.WriteLog(LogType.Trace, "success load "+lStore.Count+" stores into page.");
			return;
		}

		
        public UpdateSettings()
        {
        	Log.WriteLog(LogType.Trace, "come in UpdateSettings");
			
            InitializeComponent();
        }

        /*处理reader添加按钮点击事件*/
        private void updateSettings_addReader_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_addReader_click");
			
            comboBoxStore.Enabled = false;
            comboBoxSettings.Enabled = false;
            dgvReaders.Enabled = false;
            bAddReader.Enabled = false;
            buttonRemoveReader.Enabled = false;
            panel1.Visible = true;
            txtIP.Text = "";
            flpAntennaConfig.Controls.Clear();

			//加载reader类型
			List<string> sReaderType = new List<string>();
			sReaderType.Add("reader"); 
			sReaderType.Add("writer");
			sReaderType.Add("checker");
			cbReaderType.DataSource = sReaderType;
			
        }

		/*处理删除reader按钮点击事件*/
        private void updateSettings_rmReader_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_rmReader_click");
			
            if (dgvReaders.SelectedRows == null)
            {

            }
            else
            {
                if (MessageBox.Show("Are You sure you want to remove this reader?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (DataGridViewRow item = this.dgvReaders.SelectedRows[0])
                    {
                        int i = item.Index;

						Log.WriteLog(LogType.Trace, "success to delete reader with ip["+ reader[i].IPaddress +"]");
						
                        reader.RemoveAt(i);
						
                        dgvReaders.Rows.Clear();
                        for (int x = 0; x < reader.Count; x++)
                        {
                            dgvReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                        }

                    }
                }
            }
        }

        private void updateSettings_addAntenna_Click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_addAntenna_Click");
			
            if (AntennaList.Count < 32)
            {
                AntennaConfig ac = new AntennaConfig();

                ac.PortNumber = (AntennaList.Count + 1).ToString();
                ac.AntennaEnabled = true;
                ac.RXPower = -70;
                ac.TXPower = 30;
                ac.BorderStyle = BorderStyle.FixedSingle;

                AntennaList.Add(ac);

                flpAntennaConfig.Controls.Clear();

                if (AntennaList.Count > 4)
                {
                    AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.LightBlue;

                }

                AntennaList.ForEach(o =>
                {
                    flpAntennaConfig.Controls.Add(o);
                });
				
            }
            else
            {
                MessageBox.Show("Sorry 32 antennas, are the maximum number of antennas that the reader can support");
            }
        }

		/*处理删除reader下的antenna按钮点击事件*/
        private void updateSettings_delAntenna_Click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_delAntenna_Click");
			
            if (AntennaList.Count > 0)
            {
                AntennaConfig RemoveItem = AntennaList[AntennaList.Count - 1];

                AntennaList.Remove(RemoveItem);

                Log.WriteLog(LogType.Trace, "success to delete antenna[idx:" + RemoveItem.PortNumber + "] from memery.");

                flpAntennaConfig.Controls.Clear();

                if (AntennaList.Count <= 4)
                {
                    AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.White;
                }

                AntennaList.ForEach(o =>
                {
                    flpAntennaConfig.Controls.Add(o);
                });
            }
        }

		//判断reader的ip是否合法和是否在同一个setting下被重复配置
		private bool updateSettings_readerIpIsEnable()
		{
			string sIp = txtIP.Text;
			
            Log.WriteLog(LogType.Trace, "come in updateSettings_readerIpIsEnable");
			
			Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
            Regex rx1 = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");

            if (!rx.IsMatch(sIp))  
            {  
            	Log.WriteLog(LogType.Trace, "the ip[" + sIp+ "] format is invariable, can not create reader");
                 MessageBox.Show("Is not IP address");  
				 return false;
            }  

			
            /*判断内存里面是否已经有相同的ip*/
            for (int idx = 0; idx < reader.Count; idx++)
            {
                if (string.Equals(sIp, reader[idx].IPaddress))
                { 
                   Log.WriteLog(LogType.Trace, "the ip["+ txtIP.Text+"] has been config in store["+giStoreId+"] settings["+giSettingId+"] , please use another ip.");
                   MessageBox.Show("the ip["+ txtIP.Text+"] has been config in machine["+comboBoxStore.Text+"] settings["+comboBoxSettings.Text+"] , please use another ip.");
                   return false;
                }
            }

			return true;
		}
		

		/*处理reader submit按钮点击事件*/
        private void updateSettings_antennaSubmit_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_antennaSubmit_click");

			if (txtIP.Text == "")
			{
                Log.WriteLog(LogType.Warning, "the ip is empty, please input ip info");
                MessageBox.Show("the ip is empty, please input ip info");
                return;
			}

            if (AntennaList.Count == 0)
            {
                Log.WriteLog(LogType.Warning, "there is not antenna config info, please input them.");
                MessageBox.Show("there is not antenna config info, please input them.");
                return;
            }
			
            if (AntennaList.Count > 0 && txtIP.Text != "")
            {
            	/*判断 txtIP地址合法性*/
				if (!updateSettings_readerIpIsEnable())
				{
					return;
				}
				
            	/*生成一个reader对象*/
                Reader r = new Reader();
                r.IPaddress = txtIP.Text;
                r.numAntennas = AntennaList.Count;
				r.iReaderType = cbReaderType.SelectedIndex;

				/*生成antenna对象，并把其添加到reader对象中*/
                for (int i = 0; i < r.numAntennas; i++)
                {
                    antenna a = new antenna();
                    a.antennaNumber = Int32.Parse(AntennaList[i].PortNumber);
                    a.rxPower = AntennaList[i].RXPower;
                    a.txPower = AntennaList[i].TXPower;
                    r.antenna.Add(a);

					Log.WriteLog(LogType.Trace, 
						"success to add antenna["+i+"] into reader, the antenna info is:RxPower["+a.rxPower+"], TxPower["+a.txPower+"], antenna number["+a.antennaNumber+"]");
                }
                reader.Add(r);
				Log.WriteLog(LogType.Trace, 
									"success to add reader into memery,the reader info is:ip["+r.IPaddress+"], antenna num["+r.numAntennas+"]");
				

                comboBoxStore.Enabled = true;
                tSettingsName.Enabled = true;
                dgvReaders.Enabled = true;
                bAddReader.Enabled = true;
                buttonRemoveReader.Enabled = true;
				comboBoxSettings.Enabled = true;

		
				/*通过控件显示所有reader信息*/
                dgvReaders.Rows.Clear();
                for (int x = 0; x < reader.Count; x++)
                {
                    dgvReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                }
                
                panel1.Visible = false;
                txtIP.Text = "";
                AntennaList.Clear();
                flpAntennaConfig.Controls.Clear();

            }

        }

        private void updateSettings_back_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_back_click");
			
            ((Main)this.Parent.Parent).ChangeView<Pages.Settings.Settings>();
        }

        /*处理reader的cancel按钮点击事件*/
        private void updateSettings_antennaCancel_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateSettings_antennaCancel_click");
			
            comboBoxStore.Enabled = true;
            tSettingsName.Enabled = true;
            dgvReaders.Enabled = true;
            bAddReader.Enabled = true;
            buttonRemoveReader.Enabled = true;
			comboBoxSettings.Enabled = true;

            panel1.Visible = false;
            txtIP.Text = "";
            AntennaList.Clear();
            flpAntennaConfig.Controls.Clear();
            
        }


        private void updateSettings_btnUpdate_Click(object sender, EventArgs e)
        {
            ArrayList aDelSql = new ArrayList();
            int iSettingsID, iReaderID;
            Reader stReader;

            Log.WriteLog(LogType.Trace, "come in updateSettings_btnUpdate_Click");

			#if false //modify at 20171202
            string sCommStr = "Data Source=.; Initial Catalog=ssms; UID=sa;PASSWORD=123456;pooling=false; ";
#else
			string sCommStr = Properties.Settings.Default.ssmsConnectionString;
#endif

            /*获取settingsID*/
			iSettingsID = giSettingId;
	
			
            /*获得要删除的reader和antenna的信息*/
            if (!updateSettings_encodeSqlForDel(ref aDelSql))
            {
                Log.WriteLog(LogType.Error, "errorr to call updateSettings_encodeSqlForDel");
                return;
            }

            /*建立数据库连接*/
            using (SqlConnection conn = new SqlConnection(sCommStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    Log.WriteLog(LogType.Trace, "begin delete readers and antennas transition");
                    /*删除数据库中已有的reader和antenna配置*/
                    for (int n = 0; n < aDelSql.Count; n++)
                    {
                        string sqlString = aDelSql[n].ToString();
                        if (sqlString.Trim().Length > 1)
                        {
                            cmd.CommandText = sqlString;
                            cmd.ExecuteNonQuery();

                            Log.WriteLog(LogType.Trace, "success to exec sql[" + sqlString + "];");
                        }
                    }
                    Log.WriteLog(LogType.Trace, "success to delete all readers and antenna under store["+giStoreId+"][" + comboBoxStore.Text + "] settings["+giSettingId+"][" + comboBoxSettings.Text + "]");

                    Log.WriteLog(LogType.Trace, "goto create new readers and antennas according to memery");
                    for (int idx = 0; idx < reader.Count; idx++)
                    {
                        stReader = reader[idx];

                        /*插入reader记录*/
                        string sSql = "INSERT INTO Reader VALUES('" + stReader.IPaddress + "'," + stReader.numAntennas + ", " + iSettingsID + ", "+stReader.iReaderType +") select @@identity;";
                        cmd.CommandText = sSql;
                        iReaderID = Convert.ToInt32(cmd.ExecuteScalar());
                        Log.WriteLog(LogType.Trace, "success to exec sql[" + sSql + "];");

                        /*插入reader下所有antenna*/
                        for (int iAntIdx = 0; iAntIdx < stReader.numAntennas; iAntIdx++)
                        {
                            antenna stAnt = stReader.antenna[iAntIdx];
                            string sAntSql = "INSERT INTO Antenna VALUES(" + stAnt.txPower + ", " + stAnt.rxPower + ", " + stAnt.antennaNumber + ", " + iReaderID + ");";
                            cmd.CommandText = sAntSql;
                            cmd.ExecuteNonQuery();

                            Log.WriteLog(LogType.Trace, "success to exec sql[" + sAntSql + "];");
                        }
                    }
                    Log.WriteLog(LogType.Trace, "success to create new readers and antennas according to memery");

					//更新setting的名字
                    if (!string.Equals(comboBoxSettings.Text, tSettingsName.Text))
                    {
                        Log.WriteLog(LogType.Trace, "goto change settings[" + giSettingId + "] name from[" + comboBoxSettings.Text + "] to [" + tSettingsName.Text + "]");
                        string sSql = "update Settings set SettingsName='"+tSettingsName.Text+"' where SettingsID="+giSettingId+";";

                        cmd.CommandText = sSql;
                        cmd.ExecuteNonQuery();

                        Log.WriteLog(LogType.Trace, "success to exec sql[" + sSql + "];");
                    }

                    tx.Commit();
                    Log.WriteLog(LogType.Trace, "end transition");
					MessageBox.Show(Macro.SUCCESS_UPDATE_SETTING);

                    ((Main)this.Parent.Parent).ChangeView<UpdateSettings>();
                   

                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();

                    Log.WriteLog(LogType.Error, "error to exec sql transition, the error info is [" + E.Message + "]");

					//MessageBox.Show(E.Message);
					
                    throw E;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return ;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
