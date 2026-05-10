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
    public partial class Staff_Dashboard : Form
    {
        public Staff_Dashboard()
        {
            InitializeComponent();
        }

        private async Task LoadReservationChart()
        {
            string json =
                await ApiService.Get("Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            chart1.Series.Clear();

            chart1.Titles.Clear();

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

        private async Task LoadRoomsCount()
        {
            string json =
                await ApiService.Get("Rooms");

            var rooms =
                JsonConvert.DeserializeObject
                <List<RoomModel>>(json);

            lblRoomsCount.Text =
                rooms.Count.ToString();
        }

        private async Task LoadReservationCount()
        {
            string json =
                await ApiService.Get("Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            lblReservationCount.Text =
                reservations.Count.ToString();
        }

        
        private async Task LoadGuestCount()
        {
            string json =
                await ApiService.Get("Guests");

            var guests =
                JsonConvert.DeserializeObject
                <List<GuestsModel>>(json);

            lblGuestsCount.Text =
                guests.Count.ToString();
        }

        private async void Staff_Dashboard_Load(object sender, EventArgs e)
        {
            await LoadReservationChart();
            await LoadRoomsCount();
            await LoadReservationCount();
            await LoadGuestCount();
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            Guests form = new Guests();
            form.Show();
            this.Hide();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            Reservation form = new Reservation();
            form.Show();
            this.Hide();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            Reservation_Services form = new Reservation_Services();
            form.Show();
            this.Hide();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            Guest_check_In form = new Guest_check_In();
            form.Show();
            this.Hide();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            Payments form = new Payments();
            form.Show();
            this.Hide();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Check_Out form = new Check_Out();
            form.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
