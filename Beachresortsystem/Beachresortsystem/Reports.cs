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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_dashboard form = new Admin_dashboard();
            form.Show();
            this.Hide();
        }

        private async void Reports_Load(object sender, EventArgs e)
        {
            await LoadRoomCount();

            await LoadReservationCount();

            await LoadGuestCount();

            await LoadRevenue();

            await LoadReservationChart();

            await LoadPayments();
        }

        private async Task LoadRoomCount()
        {
            string json =
                await ApiService.Get("Rooms");

            var rooms =
                JsonConvert.DeserializeObject
                <List<RoomModel>>(json);

            lblRooms.Text =
                rooms.Count.ToString();
        }

        private async Task LoadReservationCount()
        {
            string json =
                await ApiService.Get("Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            lblReservations.Text =
                reservations.Count.ToString();
        }

        
        private async Task LoadGuestCount()
        {
            string json =
                await ApiService.Get("Guests");

            var guests =
                JsonConvert.DeserializeObject
                <List<GuestsModel>>(json);

            lblGuests.Text =
                guests.Count.ToString();
        }
        
        private async Task LoadRevenue()
        {
            string json =
                await ApiService.Get("Payments");

            var payments =
                JsonConvert.DeserializeObject
                <List<PaymentModel>>(json);

            decimal totalRevenue =
                payments.Sum(p => p.Amount);

            lblRevenue.Text =
                "₱" + totalRevenue.ToString("N2");
        }

        private async Task LoadReservationChart()
        {
            string json =
                await ApiService.Get("Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            chart1.Series.Clear();

            chart1.Series.Add("Reservations");

            chart1.Series["Reservations"]
                .IsValueShownAsLabel = true;

            var monthlyData =
                reservations
                .GroupBy(r => r.CheckInDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToList();

            string[] months =
            {
        "Jan","Feb","Mar","Apr",
        "May","Jun","Jul","Aug",
        "Sep","Oct","Nov","Dec"
    };

            foreach (var item in monthlyData)
            {
                chart1.Series["Reservations"]
                    .Points.AddXY(
                        months[item.Month - 1],
                        item.Count
                    );
            }
        }

        private async Task LoadPayments()
        {
            string json =
                await ApiService.Get("Payments");

            var payments =
                JsonConvert.DeserializeObject
                <List<PaymentModel>>(json);

            dgvPayments.DataSource =
                payments
                .OrderByDescending(
                    p => p.PaymentDate
                )
                .ToList();
            dgvPayments.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvPayments.BorderStyle =
                BorderStyle.None;

            dgvPayments.RowTemplate.Height = 35;

            dgvPayments.EnableHeadersVisualStyles =
                false;

            dgvPayments.Columns["PaymentID"]
                .HeaderText = "Payment ID";

            dgvPayments.Columns["ReservationID"]
                .HeaderText = "Reservation ID";

            dgvPayments.Columns["Amount"]
                .DefaultCellStyle.Format = "C2";

            dgvPayments.Columns["PaymentDate"]
                .DefaultCellStyle.Format =
                "MMM dd, yyyy";
        }
    }
}
