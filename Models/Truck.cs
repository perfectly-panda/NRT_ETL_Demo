using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public int Pallets { get; set; }
        public DateTime? EnterDCTime { get; set; }
        public DateTime? DockStartTime { get; set; }
        public DateTime? UnloadStartTime { get; set; }
        public DateTime? UnloadEndTime { get; set; }
        public DateTime? DockEndTime { get; set; }
        public DateTime? LeaveDCTime { get; set; }

        public DateTime Stamp { get; set; }
        public DateTime NextStamp { get; set; }

    }
}
