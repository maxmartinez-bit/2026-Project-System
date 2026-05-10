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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        private async void Payments_Load(object sender, EventArgs e)
        {
            await LoadReservations();

            await LoadPayments();

            await LoadBillInfo();
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

                cmbReservation.DataSource =
                    reservations;

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

        private async Task LoadPayments()
        {
            try
            {
                string paymentJson =
                    await ApiService.Get(
                        "Payments");

                var payments =
                    JsonConvert.DeserializeObject
                    <List<PaymentModel>>(paymentJson);

                dgvPayments.DataSource =
                    payments;

                dgvPayments.Columns["PaymentID"]
                    .HeaderText = "ID";

                dgvPayments.Columns["ReservationID"]
                    .HeaderText = "Reservation";

                dgvPayments.Columns["Amount"]
                    .HeaderText = "Amount";

                dgvPayments.Columns["PaymentDate"]
                    .HeaderText = "Date";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadBillInfo()
        {
            try
            {
                if (cmbReservation.SelectedValue == null)
                    return;

                int reservationId =
                    Convert.ToInt32(
                        cmbReservation.SelectedValue);

                // invoice
                string invoiceJson =
                    await ApiService.Get(
                        "Invoices");

                var invoices =
                    JsonConvert.DeserializeObject
                    <List<InvoiceModel>>(invoiceJson);

                var invoice =
                    invoices.FirstOrDefault(i =>
                        i.ReservationID ==
                        reservationId);

                decimal totalBill =
                    invoice?.TotalAmount ?? 0;

                // payments
                string paymentJson =
                    await ApiService.Get(
                        "Payments");

                var payments =
                    JsonConvert.DeserializeObject
                    <List<PaymentModel>>(paymentJson);

                decimal totalPaid =
                    payments
                    .Where(p =>
                        p.ReservationID ==
                        reservationId)
                    .Sum(p => p.Amount);

                decimal balance =
                    totalBill - totalPaid;

                lblTotalBill.Text =
                    "₱" + totalBill.ToString("N2");

                lblPaidAmount.Text =
                    "₱" + totalPaid.ToString("N2");

                lblBalance.Text =
                    "₱" + balance.ToString("N2");
            }
            catch
            {

            }
        }

        private async void cmbReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadBillInfo();
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                var payment = new
                {
                    ReservationID =
                        Convert.ToInt32(
                            cmbReservation.SelectedValue),

                    Amount =
                        decimal.Parse(
                            txtAmount.Text)
                };

                await ApiService.Post(
                    "Payments",
                    payment);

                MessageBox.Show(
                    "Payment successful!");

                txtAmount.Clear();

                await LoadBillInfo();

                await LoadPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Staff_Dashboard form = new Staff_Dashboard();
            form.Show();
            this.Hide();
        }
    }
}
