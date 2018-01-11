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

namespace ssms.Pages.Items
{
    public partial class UpdateBrand : UserControl
    {
    	string gBrandName;
        string gBrandDesc;
        int gBrandID;
		
    	/*加载brand信息*/
		private void UpdateBrand_Load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in UpdateBrand_Load");
			
            /*加载从数据库中brand信息*/
            DataTable stDt = Db.BrandsGetInfo();
            if (stDt == null)
            {
                Log.WriteLog(LogType.Error, "error to call BrandsGetInfo");
                return;
            }

            if (stDt.Rows.Count > 0)
            {
                Log.WriteLog(LogType.Trace, "there is [" + stDt.Rows.Count + "] brand records in db, goto show them");
                for (int n = 0; n < stDt.Rows.Count; n++)
                {
                    dgvUpdateBrand.Rows.Add(stDt.Rows[n]["BrandID"], stDt.Rows[n]["BrandName"], stDt.Rows[n]["BrandDescription"]);
                }
                Log.WriteLog(LogType.Trace, "success to load brands info into front");
            }
            else
            {
                Log.WriteLog(LogType.Trace, "there is not brand records in db, no need to show");
                
            }

            return;
			
        }

		private void dgvUpdateBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUpdateBrand.CurrentRow.Index > -1)
            {
                /*清空选中的Brand信息*/
                gBrandName = "";
                gBrandDesc = "";
                gBrandID = 0;

                /*获取选中的信息*/
                gBrandName = dgvUpdateBrand.Rows[dgvUpdateBrand.CurrentRow.Index].Cells[1].Value.ToString();
                gBrandDesc = dgvUpdateBrand.Rows[dgvUpdateBrand.CurrentRow.Index].Cells[2].Value.ToString();
                gBrandID = int.Parse( dgvUpdateBrand.Rows[dgvUpdateBrand.CurrentRow.Index].Cells[0].Value.ToString());
                Log.WriteLog(LogType.Trace, "get brand info from gritview to text box, the info is BrandID[" + gBrandID + "] Brandname[" + gBrandName + "],branddescription[" + gBrandDesc + "] ");

                tBrandName.Text = gBrandName;
                tBrandDesc.Text = gBrandDesc;
            }
        }

		private bool UpdateBrand_Params2Db(int iID, string sBrandName, string sBrandDesc)
        {
            Log.WriteLog(LogType.Trace, "come in UpdateBrand_Params2Db");

            string sSql = "update Brand set BrandName = '" + sBrandName + "', BrandDescription = '" + sBrandDesc + "' where BrandID = " + iID + ";";
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
				 
        public UpdateBrand()
        {
            InitializeComponent();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Brands>();
        }

        private void bBrandUpdate_Click(object sender, EventArgs e)
        {
            string sName, sDesc;
            int iRet, iRdID = 0;

            sName = tBrandName.Text;
            sDesc = tBrandDesc.Text;

            /*参数不能为空*/
            if (!String.IsNullOrWhiteSpace(sName) &&
                !String.IsNullOrWhiteSpace(sDesc))
            {
                if (String.Equals(sName, gBrandName) == false ||
                    String.Equals(sDesc, gBrandDesc) == false)
                {
                    /*去重*/
                    iRet = Db.BrandIsExist(sName, ref iRdID);
                    if (iRet == -1)
                    {
                        Log.WriteLog(LogType.Error, "error to call BrandIsExist");
                        //MessageBox.Show("error to call BrandIsExist");
                        return;
                    }
                    else if (iRet == 1 && iRdID != gBrandID)
                    {
                        MessageBox.Show("the name[" + sName + "] has been use,you should use another name.");
                        return;
                    }

                    /*更新数据库*/
                    if (!UpdateBrand_Params2Db(gBrandID, sName, sDesc))
                    {
                        Log.WriteLog(LogType.Error, "error to call UpdateBrand_Params2Db");
                       // MessageBox.Show("error to call UpdateBrand_Params2Db");
                        return;
                    }

                    dgvUpdateBrand.Rows[dgvUpdateBrand.CurrentRow.Index].Cells[1].Value = sName;
                    dgvUpdateBrand.Rows[dgvUpdateBrand.CurrentRow.Index].Cells[2].Value = sDesc;

					Log.WriteLog(LogType.Trace, "success to update brand id[" + gBrandID + "] with new params:name[" + sName + "] description[" + sDesc + "]");
					
                    /*清空选中的store信息*/
                    gBrandName = "";
                    gBrandDesc = "";
                    gBrandID = 0;

                    
                }
            }
            else
            {
                MessageBox.Show("please input the name and description");
            }
        }
    }
}
