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
    public partial class Guest_check_In : Form
    {
        public Guest_check_In()
        {
            InitializeComponent();
        }

        private async void Guest_check_In_Load(object sender, EventArgs e)
        {
            await LoadReservations();

            await LoadCheckInHistory();
        }
        private async Task LoadReservations()
        {
            string json =
                await ApiService.Get(
                    "Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            // RESERVED ONLY
            var reservedOnly =
                reservations
                .Where(r =>
                    r.Status == "Reserved")
                .ToList();

            cmbReservation.DataSource =
                reservedOnly;

            cmbReservation.DisplayMember =
                "ReservationID";

            cmbReservation.ValueMember =
                "ReservationID";
        }

        // =====================================
        // LOAD GRID
        // =====================================
        private async Task LoadCheckInHistory()
        {
            string json =
                await ApiService.Get(
                    "Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>(json);

            var checkedIn =
                reservations
                .Where(r =>
                    r.Status == "Checked-In")
                .Select(r => new
                {
                    ID =
                        r.ReservationID,

                    Guest =
                        r.GuestID,

                    Room =
                        r.RoomID,

                    CheckIn =
                        r.CheckInDate,

                    Status =
                        r.Status
                })
                .ToList();

           
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Staff_Dashboard form = new Staff_Dashboard();
            form.Show();
            this.Hide();
        }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                int reservationId =
                    Convert.ToInt32(
                        cmbReservation.SelectedValue);

                await ApiService.Put(
                    "Reservations/checkin/" +
                    reservationId,

                    new { });

                lblStatus.Text =
                    "Guest checked-in successfully!";

                lblStatus.ForeColor =
                    Color.Green;

                lblStatus.Visible = true;

                await LoadReservations();
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    ex.Message;

                lblStatus.ForeColor =
                    Color.Red;

                lblStatus.Visible = true;
            }
        }
    }
}
