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
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }

        

        public void ChangeView<T>() where T : Control, new()
        {
            try
            {
                panel2.Controls.Clear();
                T find = new T();
                find.Parent = panel2;
                find.Dock = DockStyle.Fill;
                find.BringToFront();
            }
            catch(Exception e)
            {

            }
        }

        private void bItems_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bItems_click");

            if (((Form1)this.Parent.Parent).scan != true)
            {
                ChangeView<Pages.Items.Items>();
            }
            
        }

        private void bItemsOut_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bItemsOut_click");

            if (((Form1)this.Parent.Parent).scan != true)
            {
                ChangeView<StockOut.StockOut>();
            }
        }


        private void bMachines_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bMachines_click");

            if (((Form1)this.Parent.Parent).scan != true)
            {
                ChangeView<Store.Store>();
            }
            
        }

        private void bSettings_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bSettings_click");

            if (((Form1)this.Parent.Parent).scan != true)
            {
                ChangeView<Pages.Settings.Settings>();
            }
            
        }

        private void bUser_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bUser_click");
            if (((Form1)this.Parent.Parent).scan != true)
            {
                if (((Form1)this.Parent.Parent).loggedIn.UserAdmin != true)
                {

                    MessageBox.Show("Sorry you do not have Admin Permission to access the Users section.");

                }
                else
                {
                    ChangeView<Users>();
                }
            }
            
        }

        private void bMyAccount_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bMyAccount_click");
            if (((Form1)this.Parent.Parent).scan != true)
            {
                ChangeView<MyAccount>();
            }
            
        }

        private void bLogOut_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bLogOut_click");
            if (((Form1)this.Parent.Parent).scan != true)
            {
            	if (MessageBox.Show("Are you sure you want to log out from the Rfid Reader Management System?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ((Form1)this.Parent.Parent).loggedIn = null;
                    ((Form1)this.Parent.Parent).ChangeView<Welcome>();
                }
                else
                {

                }
            }
            
        }

        private void bProducts_click(object sender, EventArgs e)
        {
            Log.WriteLog(LogType.Trace, "come in bProducts_click");

            if (((Form1)this.Parent.Parent).scan != true)
            {
                ChangeView<Products.Product>();
            }
            
        }

        
    }
}
