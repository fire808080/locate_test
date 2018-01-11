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
    public partial class Brands : UserControl
    {
    	/*从数据库中加载category的信息*/
        private void Brands_Load(object sender, EventArgs e)
		{
			Log.WriteLog(LogType.Trace, "come in Brands_Load");
			
			/*加载从数据库中Brands信息*/
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
					dgvBrands.Rows.Add(stDt.Rows[n]["BrandID"], stDt.Rows[n]["BrandName"], stDt.Rows[n]["BrandDescription"]);
				}
				Log.WriteLog(LogType.Trace, "success to load brand info into front");
			}
			else
			{
				Log.WriteLog(LogType.Trace, "there is not brand records in db, no need to show");
				
			}

			return;
			
		}
		
        public Brands()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();

        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.AddBrand>();
        }

        private void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.UpdateBrand>();
        }
    }
}
