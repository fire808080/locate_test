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
	
namespace ssms.Pages
{
    public partial class UpdateStore : UserControl
    {
        string gStoreName;
        string gStoreLocation;
        int gStoreID;

    	private void updateStore_load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateStore_load");
			
            /*加载从数据库中store信息*/
            DataTable stDt = Db.StoreGetInfo();
            if (stDt == null)
            {
                Log.WriteLog(LogType.Error, "error to call StoreGetInfo");
                return;
            }

            if (stDt.Rows.Count > 0)
            {
                Log.WriteLog(LogType.Trace, "there is [" + stDt.Rows.Count + "] store records in db, goto show them");
                for (int n = 0; n < stDt.Rows.Count; n++)
                {
                    dgvUpdateStore.Rows.Add(stDt.Rows[n]["StoreID"], stDt.Rows[n]["StoreName"], stDt.Rows[n]["StoreLocation"]);
                }
                Log.WriteLog(LogType.Trace, "success to load store info into front");
            }
            else
            {
                Log.WriteLog(LogType.Trace, "there is not store records in db, no need to show");
                
            }

			
			
            return;
			
        }
				
        public UpdateStore()
        {
            InitializeComponent();
        }

        private void dgvUpdateStore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			Log.WriteLog(LogType.Trace, "come in dgvUpdateStore_CellClick");

            if (dgvUpdateStore.CurrentRow.Index > -1)
            {
                /*清空选中的store信息*/
                gStoreName = "";
                gStoreLocation = "";
                gStoreID = 0;

                /*获取选中的信息*/
                gStoreName = dgvUpdateStore.Rows[dgvUpdateStore.CurrentRow.Index].Cells[1].Value.ToString();
                gStoreLocation = dgvUpdateStore.Rows[dgvUpdateStore.CurrentRow.Index].Cells[2].Value.ToString();
                gStoreID = int.Parse( dgvUpdateStore.Rows[dgvUpdateStore.CurrentRow.Index].Cells[0].Value.ToString());
                Log.WriteLog(LogType.Trace, "get store info from gritview to text box, the info is storeID[" + gStoreID + "] storename[" + gStoreName + "],location[" + gStoreLocation + "] ");

				label2.Text = gStoreID.ToString();
                txtStoreName.Text = gStoreName;
                txtStoreLocation.Text = gStoreLocation;
            }
        }

        private bool updateStore_params2Db(int iStoreID, string sStoreName, string sStoreLocation)
        {
            Log.WriteLog(LogType.Trace, "come in updateStore_params2Db");

            string sSql = "update Store set StoreName = '" + sStoreName + "', StoreLocation = '" + sStoreLocation + "' where StoreID = " + iStoreID + ";";
            try
            {
                SqlAccess.ExecuteSql(sSql);
            }
            catch(Exception ex)
            {
                //Log.WriteLog(LogType.Error, "error to call ExecuteSql");
                return false;
            }
            return true;
        }

        private void updateStore_update_click(object sender, EventArgs e)
        {
            string sStoreName, sStoreLocation;
            int iRet, iRdId = 0;

			Log.WriteLog(LogType.Trace, "come in updateStore_update_click");
			
            sStoreName = txtStoreName.Text;
            sStoreLocation = txtStoreLocation.Text;

            /*参数不能为空*/
            if (!String.IsNullOrWhiteSpace(sStoreName) &&
                !String.IsNullOrWhiteSpace(sStoreLocation))
            {
                if (String.Equals(sStoreName, gStoreName) == false ||
                    String.Equals(sStoreLocation, gStoreLocation) == false)
                {
                    /*去重*/
                    iRet = Db.StoreIsExist(sStoreName, sStoreLocation, ref iRdId);
                    if (iRet == -1)
                    {
                        Log.WriteLog(LogType.Error, "error to call StoreIsExist");
                        MessageBox.Show("error:there is something happen, process can not complete.");
                        return;
                    }
                    else if (iRet == 1)
                    {
                    	Log.WriteLog(LogType.Trace, "the name[" + sStoreName + "] has been use in location[" + sStoreLocation + "],you should use another name.");
                        MessageBox.Show("the name[" + sStoreName + "] has been use in location[" + sStoreLocation + "],you should use another name.");
						
                        return;
                    }

                    /*更新数据库*/
                    if (!updateStore_params2Db(gStoreID, sStoreName, sStoreLocation))
                    {
                        Log.WriteLog(LogType.Error, "error to call updateStore_params2Db");
                       	MessageBox.Show("error:there is something happen, process can not complete.");
						
                        return;
                    }

                    dgvUpdateStore.Rows[dgvUpdateStore.CurrentRow.Index].Cells[1].Value = sStoreName;
                    dgvUpdateStore.Rows[dgvUpdateStore.CurrentRow.Index].Cells[2].Value = sStoreLocation;

					Log.WriteLog(LogType.Trace, "success to update store[" + gStoreID + "] with new params:storename[" + sStoreName + "] storelocation[" + sStoreLocation + "]");

                    /*清空选中的store信息*/
                    gStoreName = "";
                    gStoreLocation = "";
                    gStoreID = 0;

                    //((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
                }
            }
            else
            {
                MessageBox.Show("please input the name and location");
            }
        }

        private void updateStore_back_click(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in updateStore_back_click");
			
			((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
        }
    }
}
