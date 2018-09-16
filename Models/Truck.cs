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
        public DateTime? UnloadStopTime { get; set; }
        public DateTime? DockEndTime { get; set; }
        public DateTime? LeaveDCTime { get; set; }

        public DateTime Stamp { get; set; }
        public DateTime NextStamp { get; set; }

        public int Status { get
            {

                if(LeaveDCTime != null)
                {
                    return 6;
                }
                else if (DockEndTime != null)
                {
                    return 5;
                }
                else if (UnloadStopTime != null)
                {
                    return 4;
                }
                else if (UnloadStartTime != null)
                {
                    return 3;
                }
                else if (DockStartTime != null)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }

    }
}
