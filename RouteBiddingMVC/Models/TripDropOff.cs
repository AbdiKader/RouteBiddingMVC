using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class TripDropOff
    {
        public int TripID{ get; set; }
        public Trip Trip { get; set; }
        public DateTime Appointment { get; set; }
        public int DropOffID { get; set; }
        public DropOff DropOff { get; set; }
    }
}
