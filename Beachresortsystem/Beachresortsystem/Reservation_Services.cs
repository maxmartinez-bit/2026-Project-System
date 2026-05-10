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
    public partial class Reservation_Services : Form
    {
        private int selectedId = 0;
        public Reservation_Services()
        {
            InitializeComponent();
        }
        private async Task LoadReservations()
        {
            string json =
                await ApiService.Get("Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            cmbReservation.DataSource =
                reservations;

            cmbReservation.DisplayMember =
                "ReservationID";

            cmbReservation.ValueMember =
                "ReservationID";
        }
        private async Task LoadServices()
        {
            string json =
                await ApiService.Get("Services");

            var services =
                JsonConvert.DeserializeObject
                <List<ServiceModel>>(json);

            cmbServices.DataSource =
                services;

            cmbServices.DisplayMember =
                "ServiceName";

            cmbServices.ValueMember =
                "Id";
        }

        private async Task LoadReservationServices()
        {
            // reservation services
            string rsJson =
                await ApiService.Get(
                    "ReservationServices");

            var rs =
                JsonConvert.DeserializeObject
                <List<ReservationServiceModel>>
                (rsJson);

            // services
            string serviceJson =
                await ApiService.Get("Services");

            var services =
                JsonConvert.DeserializeObject
                <List<ServiceModel>>
                (serviceJson);

            // JOIN
            var display =
                from r in rs

                join s in services
                on r.ServiceId equals s.Id

                select new
                {
                    ID = r.Id,

                    Reservation =
                        r.ReservationId,

                    Service =
                        s.ServiceName,

                    Quantity =
                        r.Quantity,

                    Total =
                        r.TotalPrice
                };

            dgvReservationServices.DataSource =
                display.ToList();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Staff_Dashboard form = new Staff_Dashboard();
            form.Show();
            this.Hide();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new
                {
                    ReservationId =
                        Convert.ToInt32(
                            cmbReservation.SelectedValue),

                    ServiceId =
                        Convert.ToInt32(
                            cmbServices.SelectedValue),

                    Quantity =
                        Convert.ToInt32(
                            txtQuantity.Text)
                };

                await ApiService.Post(
                    "ReservationServices",
                    data);

                MessageBox.Show(
                    "Service added successfully");

                await LoadReservationServices();

                txtQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvReservationServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvReservationServices
                    .Rows[e.RowIndex];

                selectedId =
                    Convert.ToInt32(
                        row.Cells["ID"].Value);

                cmbReservation.Text =
                    row.Cells["Reservation"]
                    .Value.ToString();

                cmbServices.Text =
                    row.Cells["Service"]
                    .Value.ToString();

                txtQuantity.Text =
                    row.Cells["Quantity"]
                    .Value.ToString();
            }
        }

        private async void Reservation_Services_Load(object sender, EventArgs e)
        {
            await LoadReservations();
            await LoadServices();
            await LoadReservationServices();
        }
    }
}
