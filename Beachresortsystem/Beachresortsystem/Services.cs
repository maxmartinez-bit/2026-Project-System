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
    public partial class Services : Form
    {
        int selectedServiceId = 0;

        public Services()
        {
            InitializeComponent();
        }

        private async void Services_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Add("Water Activities");
            cmbCategory.Items.Add("Food Services");
            cmbCategory.Items.Add("Transportation");
            cmbCategory.Items.Add("Room Services");
            cmbCategory.Items.Add("Spa & Wellness");

           
            cmbStatus.Items.Add("Unavailable");
            cmbStatus.Items.Add("Seasonal");

            await LoadServices();
        }

        private async Task LoadServices()
        {
            string json =
                await ApiService.Get("Services");

            var services =
                JsonConvert.DeserializeObject<List<ServiceModel>>(json);

            dgvServices.DataSource = services;
        }

        private async void btnAddservice_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceModel service = new ServiceModel()
                {
                    ServiceName = txtserviceName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Status = cmbStatus.Text,
                    Category = cmbCategory.Text
                };

                await ApiService.Post("Services", service);

                MessageBox.Show(
                    "Service added successfully!");

                await LoadServices();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            txtserviceName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();

            cmbCategory.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }

        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvServices.Rows[e.RowIndex];

                selectedServiceId =
                    Convert.ToInt32(row.Cells["Id"].Value);

                txtserviceName.Text =
                    row.Cells["ServiceName"].Value.ToString();

                txtDescription.Text =
                    row.Cells["Description"].Value.ToString();

                txtPrice.Text =
                    row.Cells["Price"].Value.ToString();

                cmbStatus.Text =
                    row.Cells["Status"].Value.ToString();

                cmbCategory.Text =
                    row.Cells["Category"].Value.ToString();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceModel service =
                    new ServiceModel()
                    {
                        Id = selectedServiceId,

                        ServiceName = txtserviceName.Text,

                        Description = txtDescription.Text,

                        Price = decimal.Parse(txtPrice.Text),

                        Status = cmbStatus.Text,

                        Category = cmbCategory.Text
                    };

                await ApiService.Put(
                    $"Services/{selectedServiceId}",
                    service);

                MessageBox.Show(
                    "Service updated successfully!");

                await LoadServices();

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
                if (selectedServiceId == 0)
                {
                    MessageBox.Show(
                        "Please select a service first.");

                    return;
                }

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this service?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    await ApiService.Delete(
                        $"Services/{selectedServiceId}");

                    MessageBox.Show(
                        "Service deleted successfully!");

                    await LoadServices();

                    ClearFields();

                    selectedServiceId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_dashboard newform = new Admin_dashboard();
            newform.Show();
            this.Hide();
        }
    }
}
