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

namespace ssms.Pages.Products
{
    public partial class Product : UserControl
    {
    	/*从数据库中加载products的信息*/
        private void Products_Load(object sender, EventArgs e)
		{
			Log.WriteLog(LogType.Trace, "come in Products_Load");
			
			/*加载从数据库中store信息*/
			DataTable stDt = Db.ProductGetInfo();
			if (stDt == null)
			{
				Log.WriteLog(LogType.Error, "error to call ProductGetInfo");
				return;
			}

			if (stDt.Rows.Count > 0)
			{
				Log.WriteLog(LogType.Trace, "there is [" + stDt.Rows.Count + "] product records in db, goto show them");
				for (int n = 0; n < stDt.Rows.Count; n++)
				{
					Log.WriteLog(LogType.Trace, "begin to load product info into front");
					
					dgvProducts.Rows.Add(stDt.Rows[n]["ProductID"], stDt.Rows[n]["ProductName"], stDt.Rows[n]["ProductDescription"],
						stDt.Rows[n]["BarcodeNumber"], stDt.Rows[n]["BrandName"], stDt.Rows[n]["CategoryName"]);
				

				Log.WriteLog(LogType.Trace, "end to load product info into front");

				}
				Log.WriteLog(LogType.Trace, "success to load product info into front");
			}
			else
			{
				Log.WriteLog(LogType.Trace, "there is not product records in db, no need to show");
				
			}

			
			
			return;
					
		}
		
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<AddProduct>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<UpdateProduct>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Items.Categories>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Items.Brands>();
        }
    }
}
