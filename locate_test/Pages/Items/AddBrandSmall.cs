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
    public partial class AddBrandSmall : UserControl
    {
        string what;
        public AddBrandSmall()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            goBack();
        }
		
		private void goBack()
        {
            if (what == "ssms.Pages.Products.AddProduct")
            {
                ((Products.AddProduct)this.Parent.Parent).doneBrand();
            }
            else
            {
                ((Products.UpdateProduct)this.Parent.Parent).doneBrand();
            }
        }

        private void AddBrandSmall_Load(object sender, EventArgs e)
        {
            what = this.Parent.Parent.ToString();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
                int iRet = 0;
                int iID = 0;
				
				if (this.tBrandName.Text == "" || this.tBrandDesc.Text == "")
	            {
                    MessageBox.Show("please input brand name and brand description.");
                    return;
	            }
				
                LTS.Brand stBrand = new LTS.Brand(); ;

                stBrand.BrandName = this.tBrandName.Text;
                stBrand.BrandDescription = this.tBrandDesc.Text;

                /*去重*/
                iRet = Db.BrandIsExist(stBrand.BrandName, ref iID);
                if (iRet == -1)
                {
                    Log.WriteLog(LogType.Error, "error to call BrandIsExist");
                    //MessageBox.Show("error to call BrandIsExist");
                    return;
                }
                else if (iRet == 1)
                {
                    Log.WriteLog(LogType.Trace, "the name [" + stBrand.BrandName + "]  already in database, you should use another name");
                    MessageBox.Show("the name[" + stBrand.BrandName + "] already in database, you should use another name.");
                    return;
                }

                /*brand添加到数据库*/
                iID = DAT.DataAccess.AddBrand(stBrand);
                if (iID != -1)
                {
                    Log.WriteLog(LogType.Trace, "success to insert brand with name[" + stBrand.BrandName + "] and id[" + iID + "]into db.");
                    MessageBox.Show("sussess to add brand name[" + stBrand.BrandName + "]into db.");
                }
                else
                {
                    Log.WriteLog(LogType.Error, "error to insert brand with name[" + stBrand.BrandName + "] into db.");
                    //MessageBox.Show("error to add brand name[" + stBrand.BrandName + "] into db.");
                }
            
        }
    }
}
