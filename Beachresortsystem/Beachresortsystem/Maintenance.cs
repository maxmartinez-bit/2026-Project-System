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
    public partial class Maintenance : Form
    {
        private int selectedMaintenanceId = 0;

        public Maintenance()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_dashboard form = new Admin_dashboard();
            form.Show();
            this.Hide();
        }

        private async void Maintenance_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Ongoing");
            cmbStatus.Items.Add("Fixed");

            await LoadRooms();

            await LoadMaintenance();
        }

        private async Task LoadRooms()
        {
            string json =
                await ApiService.Get("Rooms");

            var rooms =
                JsonConvert.DeserializeObject
                <List<RoomModel>>(json);

            cmbRoom.DataSource = rooms;

            cmbRoom.DisplayMember =
                "RoomNumber";

            cmbRoom.ValueMember =
                "RoomID";
        }

        private async Task LoadMaintenance()
        {
            string json =
                await ApiService.Get("Maintenance");

            var maintenance =
                JsonConvert.DeserializeObject
                <List<MaintenanceModel>>(json);

            dgvMaintenance.DataSource =
                maintenance;

            dgvMaintenance.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MaintenanceModel maintenance =
                    new MaintenanceModel()
                    {
                        RoomID =
                            Convert.ToInt32(
                                cmbRoom.SelectedValue
                            ),

                        Description =
                            txtDescription.Text,

                        Status =
                            cmbStatus.Text
                    };

                await ApiService.Post(
                    "Maintenance",
                    maintenance
                );

                MessageBox.Show(
                    "Maintenance saved successfully!"
                );

                await LoadMaintenance();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMaintenance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvMaintenance.Rows[e.RowIndex];

                selectedMaintenanceId =
                    Convert.ToInt32(
                        row.Cells["MaintenanceID"]
                        .Value
                    );

                cmbRoom.SelectedValue =
                    row.Cells["RoomID"].Value;

                txtDescription.Text =
                    row.Cells["Description"]
                    .Value.ToString();

                cmbStatus.Text =
                    row.Cells["Status"]
                    .Value.ToString();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMaintenanceId == 0)
            {
                MessageBox.Show(
                    "Select maintenance first."
                );

                return;
            }

            try
            {
                MaintenanceModel maintenance =
                    new MaintenanceModel()
                    {
                        MaintenanceID =
                            selectedMaintenanceId,

                        RoomID =
                            Convert.ToInt32(
                                cmbRoom.SelectedValue
                            ),

                        Description =
                            txtDescription.Text,

                        Status =
                            cmbStatus.Text
                    };

                await ApiService.Put(
                    $"Maintenance/{selectedMaintenanceId}",
                    maintenance
                );

                MessageBox.Show(
                    "Maintenance updated successfully!"
                );

                await LoadMaintenance();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMaintenanceId == 0)
            {
                MessageBox.Show(
                    "Select maintenance first."
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Delete maintenance?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                await ApiService.Delete(
                    $"Maintenance/{selectedMaintenanceId}"
                );

                MessageBox.Show(
                    "Maintenance deleted!"
                );

                await LoadMaintenance();

                ClearFields();
            }
        }

        private void ClearFields()
        {
            cmbRoom.SelectedIndex = -1;

            cmbStatus.SelectedIndex = -1;

            txtDescription.Clear();

            selectedMaintenanceId = 0;
        }
    }
}
