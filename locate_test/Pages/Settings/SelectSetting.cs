using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ssms.Util;
using ssms.DataClasses;
using System.Net.NetworkInformation;

namespace ssms.Pages.Settings
{
    public partial class SelectSetting : UserControl
    {
        List<LTS.Store> listS = new List<LTS.Store>();
        List<LTS.Settings> listSet = new List<LTS.Settings>();
 		SettingsMain smi = new SettingsMain(); //用来保存一个setting的所有信息
		List<ImpinjRevolution> impinjrev = new List<ImpinjRevolution>();


		/*获取一个store下的所有settings名字*/
		private bool SelectSetting_GetSettings()
		{
			Log.WriteLog(LogType.Trace, "come in SelectSetting_GetSettings");

			//清空原有内容
            comboBox1.DataSource = null;

			if (dataGridViewReaders.DataSource != null)
			{
				DataTable dt_tmp = (DataTable) dataGridViewReaders.DataSource;
				dt_tmp.Rows.Clear();
				dataGridViewReaders.DataSource = dt_tmp;
			}

			int iStoreIdx = comboBoxStore.SelectedIndex;
			int iStoreId = listS[iStoreIdx].StoreID;

			try
			{
	            listSet = DAT.DataAccess.GetSettings().Where(i=>i.StoreID == iStoreId).ToList();
				Log.WriteLog(LogType.Trace, "success to get ["+ listSet.Count +"]settings records for store["+iStoreId+"]");
				
				/*设置setting下拉框的值*/
				if (listSet.Count > 0)
				{
					List<string> S = new List<string>();
					
		            for (int x = 0; x < listSet.Count; x++)
		            {
		                S.Add(listSet[x].SettingsName);
		            }
					comboBox1.DataSource = S;
					comboBox1.SelectedIndex = 0;

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
		
		/*获取指定store和settings下所有reader的配置信息*/
		private bool SelectSetting_GetReaderInfo()
		{
			Log.WriteLog(LogType.Trace, "come in SelectSetting_GetReaderInfo");
		
			int iStoreIdx = comboBoxStore.SelectedIndex;
			int iSettingIdx = comboBox1.SelectedIndex;
			
			int iSettingId = listSet[iSettingIdx].SettingsID;
			int iStoreID = listS[iStoreIdx].StoreID;


			if (dataGridViewReaders.DataSource != null)
			{
				DataTable dt_tmp = (DataTable) dataGridViewReaders.DataSource;
				dt_tmp.Rows.Clear();
				dataGridViewReaders.DataSource = dt_tmp;
			}
			
			StringBuilder sSql = new StringBuilder(); 
			sSql.AppendFormat("select Reader.IPaddress, Antenna.AntennaNumber, Antenna.TxPower,Antenna.RxPower, Settings.SettingsID from Antenna ");
			sSql.AppendFormat("JOIN Reader ON Reader.ReaderID = Antenna.ReaderID ");
			sSql.AppendFormat("JOIN Settings ON Settings.SettingsID = Reader.SettingsID ");
			sSql.AppendFormat("JOIN Store ON Settings.StoreID = Store.StoreID ");
            sSql.AppendFormat("WHERE Settings.SettingsID = {0} and Store.StoreID = {1}", 
				iSettingId, iStoreID);

			
			try
			{
				DataSet stDs = SqlAccess.GetDataSet(sSql.ToString());
				DataTable stDt = stDs.Tables[0];
				
				dataGridViewReaders.DataSource = stDt;

				if (stDt.Rows.Count > 0)
				{
                	Log.WriteLog(LogType.Trace, "success to load readers info for settings[" + iSettingId + "]");
				}
				else
				{
					Log.WriteLog(LogType.Trace, "info:the settings[" + iSettingId + "] has not config reader.");
				}
			}
			catch(Exception ex)
			{
				return false;
			}
	

			return true;
		}

		private bool SelectSetting_ClearSelectFlag()
		{
			int iStoreIdx = comboBoxStore.SelectedIndex;
			int iStoreId = listS[iStoreIdx].StoreID;
			
			Log.WriteLog(LogType.Trace, "come in SelectSetting_ClearSelectFlag");

			string sSql = "UPDATE Settings SET Settings.SettingsSelect = 0 FROM Settings " + 
							"JOIN Store ON Settings.StoreID = Store.StoreID " +
							"WHERE Store.StoreID = '"+ iStoreId+ " '; ";

			try
			{
				int iRowCnt = SqlAccess.ExecuteSql(sSql);
				
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
				
		}


		/*根据store和settings名字，设置settings的select标志位*/
		private bool SelectSetting_SetSelectFlag()
		{
			string sStoreName = comboBoxStore.Text;
			int iSettingsIdx = comboBox1.SelectedIndex;
			int iSettingsId = listSet[iSettingsIdx].SettingsID;

			int iStoreIdx = comboBoxStore.SelectedIndex;
			int iStoreId = listS[iStoreIdx].StoreID;
			
			Log.WriteLog(LogType.Trace, "come in SelectSetting_SetSelectFlag");

            string sSql = "UPDATE Settings SET Settings.SettingsSelect = 1 FROM Settings " +
                            "JOIN Store ON Settings.StoreID = Store.StoreID " +
                            "WHERE Store.StoreID = '" + iStoreId + "'AND Settings.SettingsID = '" + iSettingsId + "';";


			try
			{
				int iRowCnt = SqlAccess.ExecuteSql(sSql);

                MessageBox.Show("success to set machine[" + sStoreName + "] settings[" + iSettingsId + "] into select.");
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
				
		}

		/*判断是否setting下是否有reader配置*/
		private bool SelectSetting_HasReaderConfig()
		{
			DataSet stDs;
			DataTable stDt;
			
			string sStoreName = comboBoxStore.Text;
			int iSettingsIdx = comboBox1.SelectedIndex;
			int iSettingsId = listSet[iSettingsIdx].SettingsID;
			
			Log.WriteLog(LogType.Trace, "come in SelectSetting_SetSelectFlag");

            string sSql = "select * from Reader where SettingsID = "+iSettingsId+";";

			try
			{
				stDs = SqlAccess.GetDataSet(sSql);
				stDt = stDs.Tables[0];

				if (stDt.Rows.Count == 0)
				{
					MessageBox.Show("the settings[" + iSettingsId + "] does not config reader, please change another settings.");
					return false;
				}
                
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
				
		}
		

		
		//加载settings的值
    	private void SelectSetting_Load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in SelectSetting_Load");
			
            //load store names into combo box from db
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();
			/*设置store下拉框的值*/
            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;
			comboBoxStore.SelectedIndex = 0;

			
			Log.WriteLog(LogType.Trace, "success to load the select setting page.");

        }

		//修改了store下拉框
        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)  
        {
            int iStoreIdx;
		    int iStoreId;
			
			Log.WriteLog(LogType.Trace, "come in comboBoxStore_SelectedIndexChanged");

            if (comboBoxStore.SelectedIndex > -1)
            {
            	iStoreIdx = comboBoxStore.SelectedIndex;
				iStoreId = listS[iStoreIdx].StoreID;
				
				Log.WriteLog(LogType.Trace, "goto load the settings info for store["+iStoreId+"].");
			
            	/*根据store获得setting值*/
            	if (!SelectSetting_GetSettings())
            	{
					Log.WriteLog(LogType.Error, "error to call SelectSetting_GetSettingName-2");
					return;
				}

            }

			
            return;
        } 

		//修改了setting下拉框，获取对应setting下所有reader的信息
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  
        {
            int iSettingIdx, iSettingId;
			
			Log.WriteLog(LogType.Trace, "come in comboBox1_SelectedIndexChanged");

            if (comboBox1.SelectedIndex > -1)
            {
            	iSettingIdx = comboBox1.SelectedIndex;
				iSettingId = listSet[iSettingIdx].SettingsID;

				Log.WriteLog(LogType.Trace, "goto load reader info for settings["+iSettingId+"]");
				
				/*根据store值、setting值加载reader的值*/
				if (!SelectSetting_GetReaderInfo())
				{
					Log.WriteLog(LogType.Error, "error to call SelectSetting_GetReaderInfo2");
					return;
				}
				//Log.WriteLog(LogType.Trace, "success to load readers info for settings["iSettingId"]");
			
            }
			
            return;
        } 
				
        public SelectSetting()
        {
            InitializeComponent();
        }
       
        private void buttonBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Settings>();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in btnSelect_Click");

			if (comboBoxStore.SelectedIndex > -1 && comboBox1.SelectedIndex > -1)
			{
				//判断setting是否有reader配置
				if (!SelectSetting_HasReaderConfig())
				{
					return;
				}
				
				/*清空store下所有settings的selected标志*/
				if (!SelectSetting_ClearSelectFlag())
				{
					return;
				}

				/*设置指定的setting select flag标志*/
				if (!SelectSetting_SetSelectFlag())
				{
					return;
				}

				
				((Main)this.Parent.Parent).ChangeView<Settings>();
			}
			
        }


		private void button1_Click(object sender, EventArgs e)
		{
			int iStoreId, iSettingId;
			int iStoreIdx, iSettingIdx;
			string sStoreName;
			
			Log.WriteLog(LogType.Trace, "come button1_Click");
			
			iStoreIdx = comboBoxStore.SelectedIndex;
			iStoreId = listS[iStoreIdx].StoreID;
            sStoreName = listS[iStoreIdx].StoreName;
			
			iSettingIdx = comboBox1.SelectedIndex;
			iSettingId = listSet[iSettingIdx].SettingsID;
			
			Log.WriteLog(LogType.Trace, "goto test connect machine["+iStoreId+"] settings["+iSettingId+"] readers.");

			if (!Rfid.reader_connectReader(iStoreId, iSettingId, impinjrev, null, null, null,  true))
			{
				Log.WriteLog(LogType.Error, "error to call reader_connectReader");
			}
			
			return;
		}




    }
}
