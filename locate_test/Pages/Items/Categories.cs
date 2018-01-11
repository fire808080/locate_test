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
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
        }

		/*从数据库中加载category的信息*/
        private void Categories_Load(object sender, EventArgs e)
		{
					Log.WriteLog(LogType.Trace, "come in Categories_Load");
					
					/*加载从数据库中store信息*/
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
							dgvCategories.Rows.Add(stDt.Rows[n]["CategoryID"], stDt.Rows[n]["CategoryName"], stDt.Rows[n]["CategoryDescription"]);
						}
						Log.WriteLog(LogType.Trace, "success to load category info into front");
					}
					else
					{
						Log.WriteLog(LogType.Trace, "there is not category records in db, no need to show");
						
					}
		
					
					
					return;
					
				}

        

        private void button2_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.Items>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.AddCategory>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Pages.Items.UpdateCategory>();
        }
    }
}
