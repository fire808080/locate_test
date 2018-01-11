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
    public partial class UpdateCategory : UserControl
    {
	    string gCategoryName;
        string gCategoryDesc;
        int gCategoryID;

		/*加载category信息*/
		private void UpdateCategory_Load(object sender, EventArgs e)
        {
        	Log.WriteLog(LogType.Trace, "come in UpdateCategory_Load");
			
            /*加载从数据库中category信息*/
            DataTable stDt = Db.CategoryGetInfo();
            if (stDt == null)
            {
                Log.WriteLog(LogType.Error, "error to call CategoryGetInfo");
                return;
            }

            if (stDt.Rows.Count > 0)
            {
                Log.WriteLog(LogType.Trace, "there is [" + stDt.Rows.Count + "] category records in db, goto show them");
                for (int n = 0; n < stDt.Rows.Count; n++)
                {
                    dgvUpdateCategory.Rows.Add(stDt.Rows[n]["CategoryID"], stDt.Rows[n]["CategoryName"], stDt.Rows[n]["CategoryDescription"]);
                }
                Log.WriteLog(LogType.Trace, "success to load categories info into front");
            }
            else
            {
                Log.WriteLog(LogType.Trace, "there is not category records in db, no need to show");
                
            }

            return;
			
        }

		private void dgvUpdateCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUpdateCategory.CurrentRow.Index > -1)
            {
                /*清空选中的category信息*/
                gCategoryName = "";
                gCategoryDesc = "";
                gCategoryID = 0;

                /*获取选中的信息*/
                gCategoryName = dgvUpdateCategory.Rows[dgvUpdateCategory.CurrentRow.Index].Cells[1].Value.ToString();
                gCategoryDesc = dgvUpdateCategory.Rows[dgvUpdateCategory.CurrentRow.Index].Cells[2].Value.ToString();
                gCategoryID = int.Parse( dgvUpdateCategory.Rows[dgvUpdateCategory.CurrentRow.Index].Cells[0].Value.ToString());
                Log.WriteLog(LogType.Trace, "get category info from gritview to text box, the info is categoryID[" + gCategoryID + "] categoryname[" + gCategoryName + "],categorydescription[" + gCategoryDesc + "] ");

                txtName.Text = gCategoryName;
                txtDesc.Text = gCategoryDesc;
            }
        }

		 private bool UpdateCategory_Params2Db(int iCategoryID, string sCategoryName, string sCategoryDesc)
        {
            Log.WriteLog(LogType.Trace, "come in UpdateCategory_Params2Db");

            string sSql = "update Category set CategoryName = '" + sCategoryName + "', CategoryDescription = '" + sCategoryDesc + "' where CategoryID = " + iCategoryID + ";";
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
				
        public UpdateCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Categories>();
        }

		/*提交 更新数据*/		
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sCategoryName, sCategoryDesc;
            int iRet, iRdID = 0;

            sCategoryName = txtName.Text;
            sCategoryDesc = txtDesc.Text;

            /*参数不能为空*/
            if (!String.IsNullOrWhiteSpace(sCategoryName) &&
                !String.IsNullOrWhiteSpace(sCategoryDesc))
            {
                if (String.Equals(sCategoryName, gCategoryName) == false ||
                    String.Equals(sCategoryDesc, gCategoryDesc) == false)
                {
                    /*去重*/
                    iRet = Db.CategoryIsExist(sCategoryName, ref iRdID);
                    if (iRet == -1)
                    {
                        Log.WriteLog(LogType.Error, "error to call CategoryIsExist");
                       // MessageBox.Show("error to call CategoryIsExist");
                        return;
                    }
                    else if (iRet == 1 && iRdID != gCategoryID)
                    {
                        MessageBox.Show("the name[" + sCategoryName + "] has been use,you should use another name.");
                        return;
                    }

                    /*更新数据库*/
                    if (!UpdateCategory_Params2Db(gCategoryID, sCategoryName, sCategoryDesc))
                    {
                        Log.WriteLog(LogType.Error, "error to call UpdateCategory_Params2Db");
                       // MessageBox.Show("error to call UpdateCategory_Params2Db");
                        return;
                    }

                    dgvUpdateCategory.Rows[dgvUpdateCategory.CurrentRow.Index].Cells[1].Value = sCategoryName;
                    dgvUpdateCategory.Rows[dgvUpdateCategory.CurrentRow.Index].Cells[2].Value = sCategoryDesc;

					Log.WriteLog(LogType.Trace, "success to update categoryid[" + gCategoryID + "] with new params:name[" + sCategoryName + "] description[" + sCategoryDesc + "]");
					
                    /*清空选中的store信息*/
                    gCategoryName = "";
                    gCategoryDesc = "";
                    gCategoryID = 0;

                    
                }
            }
            else
            {
                MessageBox.Show("please input the name and description");
            }
        }
    }
}
