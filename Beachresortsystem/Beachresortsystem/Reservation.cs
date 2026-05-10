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
    public partial class Reservation : Form
    {
        private int selectedReservationId = 0;
        public Reservation()
        {
            InitializeComponent();
        }

       

        private async void Reservation_Load(object sender, EventArgs e)
        {
            await LoadGuests();

            await LoadRooms();

            await LoadReservations();
        }

        private async Task LoadGuests()
        {
            string json =
                await ApiService.Get("Guests");

            var guests =
                JsonConvert.DeserializeObject
                <List<GuestsModel>>(json);

            cmbGuests.DataSource = guests;

            cmbGuests.DisplayMember = "FullName";

            cmbGuests.ValueMember = "Id";
        }

        private async Task LoadRooms()
        {
            string json =
                await ApiService.Get("Rooms");

            var rooms =
                JsonConvert.DeserializeObject
                <List<RoomModel>>(json);

            var availableRooms =
                rooms.Where(r =>
                    r.Status == "Available")
                    .ToList();

            cmbRooms.DataSource =
                availableRooms;

            cmbRooms.DisplayMember =
                "RoomNumber";

            cmbRooms.ValueMember =
                "RoomID";
        }

        private async Task LoadReservations()
        {
            // =========================
            // LOAD RESERVATIONS
            // =========================
            string reservationJson =
                await ApiService.Get("Reservations");

            var reservations =
                JsonConvert.DeserializeObject
                <List<ReservationModel>>
                (reservationJson);

            // =========================
            // LOAD GUESTS
            // =========================
            string guestJson =
                await ApiService.Get("Guests");

            var guests =
                JsonConvert.DeserializeObject
                <List<GuestsModel>>
                (guestJson);

            // =========================
            // LOAD ROOMS
            // =========================
            string roomJson =
                await ApiService.Get("Rooms");

            var rooms =
                JsonConvert.DeserializeObject
                <List<RoomModel>>
                (roomJson);

            // =========================
            // JOIN DATA
            // =========================
            var reservationDisplay =
                from r in reservations

                join g in guests
                on r.GuestID equals g.Id

                join rm in rooms
                on r.RoomID equals rm.RoomID

                select new
                {
                    ID = r.ReservationID,

                    Guest = g.FullName,

                    Room = rm.RoomNumber,

                    CheckIn =
                        r.CheckInDate.ToShortDateString(),

                    CheckOut =
                        r.CheckOutDate.ToShortDateString(),

                    Status = r.Status
                };

            dgvReservation.DataSource =
                reservationDisplay.ToList();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var reservation = new
                {
                    GuestID =
                        Convert.ToInt32(
                            cmbGuests.SelectedValue
                        ),

                    RoomID =
                        Convert.ToInt32(
                            cmbRooms.SelectedValue
                        ),

                    CheckInDate =
                        dtpCheckIn.Value,

                    CheckOutDate =
                        dtpCheckOut.Value
                };

                await ApiService.Post(
                    "Reservations",
                    reservation
                );

                MessageBox.Show(
                    "Reservation saved successfully!"
                );

                await LoadReservations();

                await LoadRooms();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row =
                        dgvReservation.Rows[e.RowIndex];

                    // reservation id
                    selectedReservationId =
                        Convert.ToInt32(
                            row.Cells[0].Value
                        );

                    // guest name
                    cmbGuests.Text =
                        row.Cells[1].Value
                        .ToString();

                    // room number
                    cmbRooms.Text =
                        row.Cells[2].Value
                        .ToString();

                    // check-in
                    dtpCheckIn.Value =
                        Convert.ToDateTime(
                            row.Cells[3].Value
                        );

                    // check-out
                    dtpCheckOut.Value =
                        Convert.ToDateTime(
                            row.Cells[4].Value
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var reservation = new
                {
                    ReservationID =
                        selectedReservationId,

                    GuestID =
                        Convert.ToInt32(
                            cmbGuests.SelectedValue
                        ),

                    RoomID =
                        Convert.ToInt32(
                            cmbRooms.SelectedValue
                        ),

                    CheckInDate =
                        dtpCheckIn.Value,

                    CheckOutDate =
                        dtpCheckOut.Value,

                    Status = "Reserved"
                };

                await ApiService.Put(
                    $"Reservations/{selectedReservationId}",
                    reservation
                );

                MessageBox.Show(
                    "Reservation updated!"
                );

                await LoadReservations();

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
                        "Delete reservation?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                if (result == DialogResult.Yes)
                {
                    await ApiService.Delete(
                        $"Reservations/{selectedReservationId}"
                    );

                    MessageBox.Show(
                        "Reservation deleted!"
                    );

                    await LoadReservations();

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
            selectedReservationId = 0;

            dtpCheckIn.Value =
                DateTime.Now;

            dtpCheckOut.Value =
                DateTime.Now;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Staff_Dashboard form = new Staff_Dashboard();
            form.Show();
            this.Hide();
        }
    }
}
