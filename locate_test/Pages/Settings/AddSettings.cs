using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ssms.DataClasses;
using ssms.Util;

namespace ssms.Pages.Settings
{
    public partial class AddSettings : UserControl
    {
        List<AntennaConfig> AntennaList = new List<AntennaConfig>();  //将页面上antenna的配置缓存在变量中，供后续操作使用
        List<Reader> reader = new List<Reader>();
        List<LTS.Store> listS;
		int giStoreId, giStoreIdx;
		
        public AddSettings()
        {
            InitializeComponent();
        }


		//修改了store下拉框
        private void addSettings_storeIdxChg(object sender, EventArgs e)  
        {
			Log.WriteLog(LogType.Trace, "come in addSettings_storeIdxChg");

            if (comboBoxStore.SelectedIndex > -1)
            {
            	giStoreIdx = comboBoxStore.SelectedIndex;
				giStoreId = listS[giStoreIdx].StoreID;
				
				Log.WriteLog(LogType.Trace, "change into config store["+giStoreId+"].");
            }
			
            return;
        } 

		
		/*添加一个天线配置对象，并将其添加到天线数组中*/
        private void addSettings_addAntenna_Click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addSettings_addAntenna_Click");
			
            if (AntennaList.Count < 32)
            {
            	/*申请天线配置对象*/
                AntennaConfig ac = new AntennaConfig();

                ac.PortNumber = (AntennaList.Count + 1).ToString();
                ac.AntennaEnabled = true;
                ac.RXPower = -70;
                ac.TXPower = 30;
                ac.BorderStyle = BorderStyle.FixedSingle;

				Log.WriteLog(LogType.Trace, "add new antenna config into memery, the antenna info is:portnumber["+ac.PortNumber+"], rxpower["+ac.RXPower+"]," +
					"txpower["+ac.TXPower+"]");
				
				/*配置对象添加到天线数组*/
                AntennaList.Add(ac);

                flpAntennaConfig.Controls.Clear();

                if (AntennaList.Count > 4)
                {
                    AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.LightBlue;
                }

				//把天线数组加载到显示控件上
                AntennaList.ForEach(o =>
                {
                    flpAntennaConfig.Controls.Add(o);
                });

				Log.WriteLog(LogType.Trace, "success to load "+AntennaList.Count+" antennas into pages.");
				
				/*使能删除按钮*/
				if (AntennaList.Count > 0 && buttonRemoveAntenna.Enabled == false)
				{
					buttonRemoveAntenna.Enabled = true;
				}
            }
            else
            {
                MessageBox.Show("Sorry 32 antennas, are the maximum number of antennas that the reader can support");
            }
        }

		/*从天线配置数组中删除一个天线对象*/
        private void addSettings_delAntenna_Click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addSettings_delAntenna_Click");
			
            if (AntennaList.Count > 0)
            {
                AntennaConfig RemoveItem = AntennaList[AntennaList.Count - 1];

                AntennaList.Remove(RemoveItem);

                Log.WriteLog(LogType.Trace, "success to remove antenna from memery, the antenna info is: portnumber[" + RemoveItem.PortNumber + "], rxpower[" + RemoveItem.RXPower + "]," +
                    "txpower[" + RemoveItem.TXPower + "]");
				
                flpAntennaConfig.Controls.Clear();

                if (AntennaList.Count <= 4 && AntennaList.Count >= 1)
                {
                    AntennaList.Where(a => a.PortNumber == "1").FirstOrDefault().BackColor = Color.White;
                }

                AntennaList.ForEach(o =>
                {
                    flpAntennaConfig.Controls.Add(o);
                });

				/*屏蔽删除按钮*/
				if (AntennaList.Count == 0)
				{
					buttonRemoveAntenna.Enabled = false;
				}
            }
        }

        private void addSettings_load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addSettings_Load");
			
            //从数据库读取store列表
            listS = DAT.DataAccess.GetStore().ToList();
            List<string> S = new List<string>();

			//加载到页面
            for (int x = 0; x < listS.Count; x++)
            {
                S.Add(listS[x].StoreName);
            }
            comboBoxStore.DataSource = S;
			comboBoxStore.SelectedIndex = 0;

			Log.WriteLog(LogType.Trace, "success load "+listS.Count+" stores into page.");
			return;
        }

		/*处理添加读写器点击事件：添加一个读写器*/
        private void addSettings_addReader_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addSettings_addReader_click");
			
        	/*判断comboBox是否已经选择和settingName是否已经填写值*/
			if (comboBoxStore.Text == "" || txtSettingsName.Text == "")
			{
				MessageBox.Show("please in put setting name or selecet mechine");  
				return;
			}

			/*暂时屏蔽控件可用性*/
            comboBoxStore.Enabled = false;
            txtSettingsName.Enabled = false;
            dataGridViewReaders.Enabled = false;
            btAddReader.Enabled = false;
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

		/*处理读写器submit点击事件:添加一个读写器对象，并将其加入读写器队列*/
        private void addSettings_antennaSubmit_Click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addSetting_antennaSubmit_Click");
			
            if (AntennaList.Count > 0 && txtIP.Text !="")
            {
                Reader stReader = new Reader();

				/*判断 txtIP地址合法性*/
				{
					string sIp = txtIP.Text;
					Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");  
		            if (!rx.IsMatch(sIp))  
		            {  
		            	Log.WriteLog(LogType.Trace, "the ip[" + sIp+ "] format is invariable, can not create reader");
		                 MessageBox.Show("Is not IP address");  
						 return;
		            }  

					/*判断该ip在该store和setting下是否已经配置过，如果是，则先删除之前的reader配置，才能配置新的*/
                    string sSql = "SELECT Reader.ReaderID FROM Reader " +
                        "JOIN Settings ON Reader.SettingsID = Settings.SettingsID " +
                        "JOIN Store ON Settings.StoreID = Store.StoreID " +
                        "WHERE Store.StoreID = " + giStoreId + " and Settings.SettingsName = '" + txtSettingsName.Text + "' and Reader.IPaddress = '" + txtIP.Text + "';";
                    try
                    {
                        DataSet stDs = SqlAccess.GetDataSet(sSql);
                        if (stDs.Tables[0].Rows.Count > 0)
                        { 
                           Log.WriteLog(LogType.Trace, "the ip["+ txtIP.Text+"] has been config in store["+giStoreId+"] setting["+txtSettingsName.Text+"] reader, please delete it first3");
                           MessageBox.Show("the ip["+txtIP.Text+"] has been config in machine["+giStoreId+"] setting["+txtSettingsName.Text+"] reader, please delete it first3");
						   return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("process termination, because error to get reader id");
                        return ;
                    }

					/*判断内存里面是否已经有相同的ip*/
                    for (int idx = 0; idx < reader.Count; idx++)
                    {
                        if (string.Equals(sIp, reader[idx].IPaddress))
                        {
                            Log.WriteLog(LogType.Trace, "the ip[" + sIp + "] has been config in this add route, please delete it first5");
                            MessageBox.Show("the ip[" + sIp + "] has been config in this add route, please delete it first5");
                            return;
                        }
                    }
					
				}

				/*将天线配置及读写器ip写入读写器对象*/
                stReader.IPaddress = txtIP.Text;
				stReader.iReaderType = cbReaderType.SelectedIndex;
                stReader.numAntennas = AntennaList.Count;
                for (int i = 0; i < stReader.numAntennas; i++)
                {
                    antenna a = new antenna();
                    a.antennaNumber = Int32.Parse(AntennaList[i].PortNumber);
                    a.rxPower = AntennaList[i].RXPower;
                    a.txPower = AntennaList[i].TXPower;
                    stReader.antenna.Add(a);

					Log.WriteLog(LogType.Trace, 
						"success to add antenna["+i+"] into reader, the antenna info is:RxPower["+a.rxPower+"], TxPower["+a.txPower+"], antenna number["+a.antennaNumber+"]");
                }

				//reader添加到reader数组
                reader.Add(stReader);
				Log.WriteLog(LogType.Trace, 
					"success to add reader into memery,the reader info is:ip["+stReader.IPaddress+"], antenna num["+stReader.numAntennas+"], readerType["+stReader.iReaderType+"]");

				//使能控件可用性
                comboBoxStore.Enabled = true;
                txtSettingsName.Enabled = true;
                dataGridViewReaders.Enabled = true;
                btAddReader.Enabled = true;
                buttonRemoveReader.Enabled = true;
                dataGridViewReaders.Rows.Clear();

				//reader信息加载到显示控件
                for(int x =0; x < reader.Count; x++)
                {
                    dataGridViewReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                }
                panel1.Visible = false;
                txtIP.Text = "";
                AntennaList.Clear();
                flpAntennaConfig.Controls.Clear();

            }
			else
			{
				MessageBox.Show("please input reader ip address and antenna infomation.");
			}
            
        }

		/*处理删除一个读写器点击事件:删除一个读写器配置*/
        private void addSettings_delReader_click(object sender, EventArgs e)  
        {
        	Log.WriteLog(LogType.Trace, "come in addSettings_delReader_click");
			
            if (dataGridViewReaders.SelectedRows == null)
            {
				MessageBox.Show("please channge one reader1");
				return;
            }
            else
            {
            	if (dataGridViewReaders.CurrentRow == null)
            	{
            		MessageBox.Show("please channge one reader2");
					return;
            	}
				
                if (MessageBox.Show("Are You sure you want to remove this reader?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (DataGridViewRow item = this.dataGridViewReaders.SelectedRows[0])
                    {
                        int i = item.Index;
                        reader.RemoveAt(i);
                        dataGridViewReaders.Rows.Clear();
                        for (int x = 0; x < reader.Count; x++)
                        {
                            dataGridViewReaders.Rows.Add(reader[x].IPaddress, reader[x].numAntennas);
                        }

						Log.WriteLog(LogType.Trace, "success to delete reader with index["+item.Index+"]");
                    }
					
					
					
                }
            }
        }

		/*处理back按钮点击事件：回退到上一级*/
        private void addSettings_back_Click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in addSettings_back_Click");
		
            ((Main)this.Parent.Parent).ChangeView<Settings>();
        }

		/*处理添加setting按钮点击事件*/
        private void addSettings_add_click(object sender, EventArgs e)
        {
        	StringBuilder sLogStr = new StringBuilder();
			
        	Log.WriteLog(LogType.Trace, "come in addSettings_add_click");
			
			int iIdx = 0;
			int iSettingsId = 0;

			/*添加settings记录*/
			if (!SqlAccess.SA_AddSettings(comboBoxStore.Text, giStoreId, txtSettingsName.Text,ref iSettingsId))
			{
				Log.WriteLog(LogType.Error, "Error to call SqlAccess.SA_AddSettings");
				
				return;
			}
			
			/*遍历reader数组，添加reader记录*/
			for (iIdx = 0; iIdx < reader.Count; iIdx++)
			{
				sLogStr.Length = 0;
                sLogStr.AppendFormat("goto add reader with indxe[{0}]", iIdx);
				Log.WriteLog(LogType.Trace, sLogStr);
				
				if (!SqlAccess.SA_AddReader(reader[iIdx], iSettingsId))
				{
					Log.WriteLog(LogType.Error, "Error to call SqlAccess.SA_AddSettings");
					
					return;
				}
			}
            
			MessageBox.Show(Macro.SUCCESS_ADD_SETTING);

        }


		/*处理reader的cancle按钮点击事件*/
        private void addSettings_cancle_Click(object sender, EventArgs e)
        {
            comboBoxStore.Enabled = true;
            txtSettingsName.Enabled = true;
            dataGridViewReaders.Enabled = true;
            btAddReader.Enabled = true;
            buttonRemoveReader.Enabled = true;

            panel1.Visible = false;
            txtIP.Text = "";
            AntennaList.Clear();
            flpAntennaConfig.Controls.Clear();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}