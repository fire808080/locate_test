using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ssms.LTS;
using ssms.DAT;
using ssms.Util;


namespace ssms.Pages
{
    public partial class AddStore : UserControl
    {
        public AddStore()
        {
            InitializeComponent();
        }

        private void addStore_add_Click(object sender, EventArgs e)
        {
            int iRet = 0;
			int iID = 0;
            LTS.Store stStore = new LTS.Store(); ;

			Log.WriteLog(LogType.Trace, "come in addStore_add_Click");
			
            stStore.StoreName = this.txtName.Text;
            stStore.StoreLocation = this.txtSur.Text;
			
            /*去重*/
            iRet = Db.StoreIsExist(stStore.StoreName, stStore.StoreLocation, ref iID);
            if (iRet == -1)
            {
                Log.WriteLog(LogType.Error, "error to call MachineIsExist");
                //MessageBox.Show("error to call StoreIsExist");
                return;
            }
            else if(iRet == 1)
            {
            	Log.WriteLog(LogType.Trace, "the name[" + stStore.StoreName + "] has been use in location[" + stStore.StoreLocation + "],you should use another name.");
                MessageBox.Show("the name[" + stStore.StoreName + "] has been use in location[" + stStore.StoreLocation + "],you should use another name.");
				
                return;
            }

            /*store添加到数据库*/
            iID = DAT.DataAccess.AddStore(stStore);
			if (iID != -1)
			{
				Log.WriteLog(LogType.Trace, "success to insert store with name["+stStore.StoreName+"],location["+stStore.StoreLocation+"] and id["+iID+"]into db.");
            	MessageBox.Show("sussess to add machine name[" + stStore.StoreName + "]in location[" + stStore.StoreLocation + "].");
				
				((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
			}
			else
			{
                Log.WriteLog(LogType.Error, "error to insert machine with name[" + stStore.StoreName + "] and location[" + stStore.StoreLocation + "] into db");
				MessageBox.Show("error to add store name[" + stStore.StoreName + "]in location[" + stStore.StoreLocation + "].");
				
				((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
				
			}
        }

        private void addStore_back_click(object sender, EventArgs e)
        {
			Log.WriteLog(LogType.Trace, "come in addStore_back_click");

			((Main)this.Parent.Parent).ChangeView<Pages.Store.Store>();
			return;
        }
    }
}
