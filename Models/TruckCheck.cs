using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TruckCheck
    {
        public int TruckId { get; set; }
        public DateTime Stamp { get; set; }
        public DateTime NextStamp { get; set; }
        public int Pallets { get; set; }
    }
}
