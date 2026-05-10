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
    public partial class Staff_Management : Form
    {
        private int selectedUserId = 0;

        public Staff_Management()
        {
            InitializeComponent();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Staff_Management_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            string json =
                await ApiService.Get("User");

            var users =
                JsonConvert.DeserializeObject
                <List<UserModel>>(json);

            dgvUsers.DataSource = users;

            dgvUsers.Columns["Password"].Visible = false;
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                UserModel user =
                    new UserModel()
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        Role = cmbRole.Text
                    };

                await ApiService.Post(
                    "User/register",
                    user
                );

                MessageBox.Show(
                    "User added successfully!"
                );

                await LoadUsers();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show(
                    "Select user first."
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Delete this user?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                await ApiService.Delete(
                    $"User/{selectedUserId}"
                );

                MessageBox.Show(
                    "User deleted successfully!"
                );

                await LoadUsers();

                ClearFields();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvUsers.Rows[e.RowIndex];

                selectedUserId =
                    Convert.ToInt32(
                        row.Cells["Id"].Value
                    );

                txtUsername.Text =
                    row.Cells["Username"]
                    .Value.ToString();

                cmbRole.Text =
                    row.Cells["Role"]
                    .Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();

            cmbRole.SelectedIndex = -1;

            selectedUserId = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_dashboard admin = new Admin_dashboard();
            admin.Show();
            this.Hide();
        }
    }
}
