using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beachresortsystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void showPass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
            !txtPassword.UseSystemPasswordChar;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var loginData = new
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };

                string result =
                    await ApiService.Post(
                        "User/login",
                        loginData
                    );

                // INVALID LOGIN
                if (result.Contains("Invalid"))
                {
                    MessageBox.Show(
                        result,
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                // SUCCESS LOGIN
                LoginResponse user =
                    JsonConvert.DeserializeObject<LoginResponse>(result);

                MessageBox.Show(
                    "Welcome " + user.Username,
                    "Login Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // OPEN DASHBOARD
                // =====================================
                // ROLE BASED LOGIN
                // =====================================

                if (user.Role == "Admin")
                {
                    Admin_dashboard admin =
                        new Admin_dashboard();

                    admin.Show();
                }

                else if (user.Role == "Staff")
                {
                    Staff_Dashboard staff =
                        new Staff_Dashboard();

                    staff.Show();
                }

                else
                {
                    MessageBox.Show(
                        "Unknown role detected."
                    );

                    return;
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CenterPanel()
        {
            Loginpanel.Left =
                (this.ClientSize.Width - Loginpanel.Width) / 2;

            Loginpanel.Top =
                (this.ClientSize.Height - Loginpanel.Height) / 2;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
