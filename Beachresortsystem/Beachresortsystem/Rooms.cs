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
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Rooms_Load(object sender, EventArgs e)
        {
            cmbRoomType.Items.Add("Standard");
            cmbRoomType.Items.Add("Deluxe");
            cmbRoomType.Items.Add("Suite");
            cmbRoomType.Items.Add("VIP");

            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Occupied");
            cmbStatus.Items.Add("Maintenance");

            await LoadRooms();
        }

        private async Task LoadRooms()
        {
            string json =
                await ApiService.Get("Rooms");

            var rooms =
                JsonConvert.DeserializeObject<List<RoomModel>>(json);

            dgvRooms.DataSource = rooms;
        }

        private async void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                RoomModel room = new RoomModel()
                {
                    RoomNumber = txtRoomNumber.Text,
                    RoomType = cmbRoomType.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Status = cmbStatus.Text
                };

                await ApiService.Post("Rooms", room);

                MessageBox.Show(
                    "Room added successfully!");

                await LoadRooms();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            txtRoomNumber.Clear();
            txtPrice.Clear();

            cmbRoomType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_dashboard newform = new Admin_dashboard();
            newform.Show();
            this.Hide();
        }
    }
}
