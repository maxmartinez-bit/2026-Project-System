using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beachresortsystem
{
    internal class ServiceModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string Category { get; set; }
    }
}
