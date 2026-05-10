using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beachresortsystem
{
    internal class ReservationServiceModel
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public int ServiceId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
