using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beachresortsystem
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
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
        
        private void btnRooms_Click(object sender, EventArgs e)
        { 
            Rooms roomsForm = new Rooms();
            roomsForm.Show();
            this.Hide();
        }

        private void btnServices_Click_1(object sender, EventArgs e)
        {
            Services serviceForm = new Services();
            serviceForm.Show();
            this.Hide();
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            Staff_Management staffForm = new Staff_Management();
            staffForm.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports reportForm = new Reports();
            reportForm.Show();
            this.Hide();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            Maintenance maintenanceform = new Maintenance();
            maintenanceform.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private async void Admin_dashboard_Load(object sender, EventArgs e)
        {
            await LoadReservationChart();
            await LoadRoomsCount();
            await LoadReservationCount();
            await LoadGuestCount();
        }

        private bool isDarkMode = false;
        private void btnDarkMood_Click(object sender, EventArgs e)
        {
            if (!isDarkMode)
            {
                // FORM
                this.BackColor =
                    Color.FromArgb(30, 30, 30);

                // SIDEBAR
                panelSidebar.BackColor =
                    Color.FromArgb(20, 20, 20);

                // MAIN PANEL
                panelMain.BackColor =
                    Color.FromArgb(40, 40, 40);

                // LABELS
                label1.ForeColor = Color.White;
                lblRooms.ForeColor = Color.White;
                lblReservations.ForeColor = Color.White;
                lblGuests.ForeColor = Color.White;

                // CHART
                chart1.BackColor =
                    Color.FromArgb(40, 40, 40);

                chart1.ChartAreas[0]
                    .BackColor =
                    Color.FromArgb(40, 40, 40);

                chart1.ChartAreas[0]
                    .AxisX.LabelStyle.ForeColor =
                    Color.White;

                chart1.ChartAreas[0]
                    .AxisY.LabelStyle.ForeColor =
                    Color.White;

                chart1.ChartAreas[0]
                    .AxisX.LineColor =
                    Color.White;

                chart1.ChartAreas[0]
                    .AxisY.LineColor =
                    Color.White;

                // BUTTON TEXT
                btnDarkMode.Text =
                    "☀ Light Mode";

                isDarkMode = true;
            }
            else
            {
                // FORM
                this.BackColor =
                    Color.FromArgb(242, 220, 179);

                // SIDEBAR
                panelSidebar.BackColor =
                    Color.FromArgb(35, 35, 35);

                // MAIN PANEL
                panelMain.BackColor =
                    Color.FromArgb(242, 220, 179);

                // LABELS
                label1.ForeColor = Color.Black;
                lblRooms.ForeColor = Color.Black;
                lblReservations.ForeColor = Color.Black;
                lblGuests.ForeColor = Color.Black;

                // CHART
                chart1.BackColor = Color.White;

                chart1.ChartAreas[0]
                    .BackColor = Color.White;

                chart1.ChartAreas[0]
                    .AxisX.LabelStyle.ForeColor =
                    Color.Black;

                chart1.ChartAreas[0]
                    .AxisY.LabelStyle.ForeColor =
                    Color.Black;

                // BUTTON TEXT
                btnDarkMode.Text =
                    "🌙 Dark Mode";

                isDarkMode = false;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
