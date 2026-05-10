using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beachresortsystem
{
    internal class PaymentModel
    {
        public int PaymentID { get; set; }

        public int ReservationID { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
