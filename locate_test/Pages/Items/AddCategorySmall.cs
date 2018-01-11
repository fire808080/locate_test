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
    public partial class AddCategorySmall : UserControl
    {
        string what;
        public AddCategorySmall()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            if (what == "ssms.Pages.Products.AddProduct")
            {
                ((Products.AddProduct)this.Parent.Parent).doneCategory();
            }
            else
            {
                ((Products.UpdateProduct)this.Parent.Parent).doneCategory();
            }
        }

        private void AddCategorySmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                int iRet = 0;
                int iID = 0;
				
				if (this.tCateName.Text == "" || this.tCateDesc.Text == "")
	            {
                    MessageBox.Show("please input category name and category description.");
                    return;
	            }
				
                LTS.Category stCate = new LTS.Category(); ;

                stCate.CategoryName = this.tCateName.Text;
                stCate.CategoryDescription = this.tCateDesc.Text;

                /*去重*/
                iRet = Db.CategoryIsExist(stCate.CategoryName, ref iID);
                if (iRet == -1)
                {
                    Log.WriteLog(LogType.Error, "error to call CategoryIsExist");
                    //MessageBox.Show("error to call CategoryIsExist");
                    return;
                }
                else if (iRet == 1)
                {
                    Log.WriteLog(LogType.Trace, "the name [" + stCate.CategoryName + "]  already in database, you should use another name");
                    MessageBox.Show("the name[" + stCate.CategoryName + "] already in database, you should use another name.");
                    return;
                }

                /*brand添加到数据库*/
                iID = DAT.DataAccess.AddCategory(stCate);
                if (iID != -1)
                {
                    Log.WriteLog(LogType.Trace, "success to insert category with name[" +  stCate.CategoryName + "] and id[" + iID + "]into db.");
                    MessageBox.Show("sussess to add category name[" +  stCate.CategoryName + "]into db.");
                }
                else
                {
                    Log.WriteLog(LogType.Error, "error to insert category with name[" +  stCate.CategoryName + "] into db.");
                    //MessageBox.Show("error to add category name[" +  stCate.CategoryName + "] into db.");
                }
            
        }
    }
}
