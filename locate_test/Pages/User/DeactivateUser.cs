﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssms.Pages
{
    public partial class DeactivateUser : UserControl
    {
        string getID = "";
        bool activated;
        public DeactivateUser()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Parent.Parent).ChangeView<Users>();
        }


        private void DeactivateUser_Load(object sender, EventArgs e)
        {
            try
            {
                activated = true;
                string isAdminActivated = "";
                string isUserActivated = "";
                List<LTS.User> user = new List<LTS.User>();
                user = DAT.DataAccess.GetUser().Where(o => o.UserActivated.Equals(activated)).ToList();
                for (int i = 0; i < user.Count; i++)
                {
                    if (((Form1)this.Parent.Parent.Parent.Parent).loggedIn.UserID != user[i].UserID)
                    {
                        if (user[i].UserAdmin == true) { isAdminActivated = "Yes"; } else { isAdminActivated = "No"; }
                        if (user[i].UserActivated == true) { isUserActivated = "Yes"; } else { isUserActivated = "No"; }
                        dgvUser.Rows.Add(user[i].UserID, user[i].UserIdentityNumber, user[i].UserName, user[i].UserSurname, user[i].UserEmail, isAdminActivated, isUserActivated);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //ID Search button clicked
                string searchValue = tbSearch.Text;
                bool foundSearch = false;
                if (tbSearch.Text == "") { MessageBox.Show("No User Identity number was entered"); }
                dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dgvUser.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(searchValue))
                        {
                            dgvUser.ClearSelection();
                            row.Selected = true;
                            tbSearch.Text = "";
                            foundSearch = true;
                            break;
                        }
                    }
                    if (foundSearch == false) { MessageBox.Show("No user was found"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The user could not be found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }

 
        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    LTS.User user = new LTS.User();
                    bool activated = false;

					//从数据库中获取指定用户的信息并更新
                    List<LTS.User> userList = new List<LTS.User>();
                    userList = DAT.DataAccess.GetUser().Where(o => o.UserID == int.Parse(getID)).ToList();


                    user.UserID = userList[0].UserID;
                    user.UserActivated = false;
                    user.UserAdmin = DAT.DataAccess.GetUser().Where(o => o.UserID == userList[0].UserID).FirstOrDefault().UserAdmin;
                    user.UserEmail = DAT.DataAccess.GetUser().Where(o => o.UserID == userList[0].UserID).FirstOrDefault().UserEmail;
                    user.UserIdentityNumber = DAT.DataAccess.GetUser().Where(o => o.UserID == userList[0].UserID).FirstOrDefault().UserIdentityNumber;
                    user.UserName = DAT.DataAccess.GetUser().Where(o => o.UserID == userList[0].UserID).FirstOrDefault().UserSurname;
                    user.UserSurname = DAT.DataAccess.GetUser().Where(o => o.UserID == userList[0].UserID).FirstOrDefault().UserSurname;
                    user.UserPassword = DAT.DataAccess.GetUser().Where(o => o.UserID == userList[0].UserID).FirstOrDefault().UserPassword;

                    bool ok;

					//将最新的用户信息更新到数据库
                    ok = DAT.DataAccess.UpdateUser(user);

                    if (ok == false)
                    {
                        if (DialogResult.OK == MessageBox.Show("There was something wrong, the User was not Deactivated!"))
                        {
                            ((Main)this.Parent.Parent).ChangeView<DeactivateUser>();
                        }
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("The User was Deactivated successfully!"))
                        {
                            ((Main)this.Parent.Parent).ChangeView<DeactivateUser>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The User was not Deactivated successfully!");
                    ((Main)this.Parent.Parent).ChangeView<DeactivateUser>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            

        }

        //记下所选用户的id
        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 1)
            {
                using (DataGridViewRow item = this.dgvUser.SelectedRows[0])
                {
                    int i = item.Index;
                    getID = "";

                    getID = dgvUser.Rows[i].Cells[0].Value.ToString();

                }
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            try
            {
                //Search button clicked
                string searchValue = tbSearchName.Text;
                bool foundSearch = false;
                if (tbSearchName.Text == "") { MessageBox.Show("No User name was entered"); }
                dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dgvUser.Rows)
                    {
                        if (row.Cells[2].Value.ToString().Equals(searchValue))
                        {
                            dgvUser.ClearSelection();
                            row.Selected = true;
                            tbSearchName.Text = "";
                            foundSearch = true;
                            break;
                        }
                    }
                    if (foundSearch == false) { MessageBox.Show("No user was found"); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The user could not be found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry Something went wrong, the action was not completed!");
            }
            
        }
    }
}
