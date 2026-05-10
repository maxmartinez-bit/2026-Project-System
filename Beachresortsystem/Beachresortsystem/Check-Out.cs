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
    public partial class Check_Out : Form
    {
        public Check_Out()
        {
            InitializeComponent();
        }

        private async void Check_Out_Load(object sender, EventArgs e)
        {
            await LoadReservations();

        }

        private async Task LoadReservations()
        {
            try
            {
                string json =
                    await ApiService.Get(
                        "Reservations");

                var reservations =
                    JsonConvert.DeserializeObject
                    <List<ReservationModel>>(json);

                // checked-in only
                var checkedIn =
                    reservations
                    .Where(r =>
                        r.Status == "Checked-In")
                    .ToList();

                cmbReservation.DataSource =
                    checkedIn;

                cmbReservation.DisplayMember =
                    "ReservationID";

                cmbReservation.ValueMember =
                    "ReservationID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                int reservationId =
                    Convert.ToInt32(
                        cmbReservation.SelectedValue);

                await ApiService.Put(
                    "Reservations/checkout/" +
                    reservationId,

                    new { });

                lblStatus.Text =
                    "Guest checked-out successfully!";

                lblStatus.ForeColor =
                    Color.Red;

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Staff_Dashboard form = new Staff_Dashboard();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
