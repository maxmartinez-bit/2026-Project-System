using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Beachresortsystem
{
    public partial class Guests : Form
    {
        private int selectedGuestId = 0;

        public Guests()
        {
            InitializeComponent();
        }

        private async Task LoadGuests()
        {
            string json =
                await ApiService.Get("Guests");

            var guests =
                JsonConvert.DeserializeObject
                <List<GuestsModel>>(json);

            dgvGuests.DataSource = guests;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Staff_Dashboard form = new Staff_Dashboard();
            form.Show();
            this.Hide();
        }

        private async void Guests_Load(object sender, EventArgs e)
        {
            await LoadGuests();
        }

        private async void btnAddguests_Click(object sender, EventArgs e)
        {
            try
            {
                var guest = new
                {
                    FullName = txtFullname.Text,
                    ContactNumber = txtContact.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text
                };

                await ApiService.Post(
                    "Guests",
                    guest
                );

                MessageBox.Show(
                    "Guest added successfully!"
                );

                await LoadGuests();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvGuests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvGuests.Rows[e.RowIndex];

                selectedGuestId =
                    Convert.ToInt32(
                        row.Cells["Id"].Value
                    );

                txtFullname.Text =
                    row.Cells["FullName"].Value
                    .ToString();

                txtContact.Text =
                    row.Cells["ContactNumber"]
                    .Value.ToString();

                txtEmail.Text =
                    row.Cells["Email"].Value
                    .ToString();

                txtAddress.Text =
                    row.Cells["Address"].Value
                    .ToString();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var guest = new
                {
                    Id = selectedGuestId,
                    FullName = txtFullname.Text,
                    ContactNumber = txtContact.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text
                };

                await ApiService.Put(
                    $"Guests/{selectedGuestId}",
                    guest
                );

                MessageBox.Show(
                    "Guest updated successfully!"
                );

                await LoadGuests();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result =
                    MessageBox.Show(
                        "Delete this guest?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                if (result == DialogResult.Yes)
                {
                    await ApiService.Delete(
                        $"Guests/{selectedGuestId}"
                    );

                    MessageBox.Show(
                        "Guest deleted successfully!"
                    );

                    await LoadGuests();

                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            txtFullname.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            selectedGuestId = 0;
        }
    }
}
