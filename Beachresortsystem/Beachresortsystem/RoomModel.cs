using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beachresortsystem
{
    internal class RoomModel
    {
        public int RoomID { get; set; }

        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }
    }
}
