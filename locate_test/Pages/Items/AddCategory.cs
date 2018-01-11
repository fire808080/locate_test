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
    public partial class AddCategory : UserControl
    {
        public AddCategory()
        {
            InitializeComponent();
        }

		/*回退到categories页面*/
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Categories>();
        }

        /*添加category项*/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int iRet = 0;
			int iID = 0;
            LTS.Category stCategory = new LTS.Category(); ;
            
            stCategory.CategoryName = this.txtCatName.Text;
           	stCategory.CategoryDescription = this.txtCatDesc.Text;
			
            /*去重*/
            iRet = Db.CategoryIsExist(stCategory.CategoryName, ref iID);
            if (iRet == -1)
            {
                Log.WriteLog(LogType.Error, "error to call CategoryIsExist");
                //MessageBox.Show("error to call CategoryIsExist");
                return;
            }
            else if(iRet == 1)
            {
                Log.WriteLog(LogType.Trace, "the name [" + stCategory.CategoryName + "]  already in database, you should use another name");
                MessageBox.Show("the name[" + stCategory.CategoryName + "] already in database, you should use another name.");
                return;
            }

            /*category添加到数据库*/
            iID = DAT.DataAccess.AddCategory(stCategory);
			if (iID !=-1)
			{
                Log.WriteLog(LogType.Trace, "success to insert category with name[" + stCategory.CategoryName + "] and id["+iID+"]into db.");
                MessageBox.Show("sussess to add category name[" + stCategory.CategoryName + "]into db.");
			}
			else
			{
                Log.WriteLog(LogType.Error, "error to insert category with name[" + stCategory.CategoryName + "] into db.");
                //MessageBox.Show("error to add category name[" + stCategory.CategoryName + "] into db.");
			}
        }
    }
}
