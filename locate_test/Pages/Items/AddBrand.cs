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
    public partial class AddBrand : UserControl
    {
        public AddBrand()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Brands>();
        }

		/*添加brand*/
        private void btnBrandAdd_Click(object sender, EventArgs e)
        {
            int iRet = 0;
			int iID = 0;
            LTS.Brand stBrand = new LTS.Brand(); ;

            stBrand.BrandName = this.txtBrandName.Text;
            stBrand.BrandDescription = this.txtBrandDesc.Text;
			
            /*去重*/
            iRet = Db.BrandIsExist(stBrand.BrandName, ref iID);
            if (iRet == -1)
            {
                Log.WriteLog(LogType.Error, "error to call BrandIsExist");
                //MessageBox.Show("error to call BrandIsExist");
                return;
            }
            else if(iRet == 1)
            {
                Log.WriteLog(LogType.Trace, "the name [" + stBrand.BrandName + "]  already in database, you should use another name");
                MessageBox.Show("the name[" + stBrand.BrandName + "] already in database, you should use another name.");
                return;
            }

            /*brand添加到数据库*/
            iID = DAT.DataAccess.AddBrand(stBrand);
			if (iID !=-1)
			{
                Log.WriteLog(LogType.Trace, "success to insert brand with name[" + stBrand.BrandName + "] and id[" + iID + "]into db.");
                MessageBox.Show("sussess to add category name[" + stBrand.BrandName + "]into db.");
			}
			else
			{
                Log.WriteLog(LogType.Error, "error to insert category with name[" + stBrand.BrandName + "] into db.");
                //MessageBox.Show("error to add category name[" + stBrand.BrandName + "] into db.");
			}
        }
    }
}
