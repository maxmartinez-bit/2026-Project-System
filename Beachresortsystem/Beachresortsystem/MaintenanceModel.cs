using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beachresortsystem
{
    internal class MaintenanceModel
    {
        public int MaintenanceID { get; set; }

        public int RoomID { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime DateReported { get; set; }
    }
}
