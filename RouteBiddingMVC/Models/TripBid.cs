using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class TripBid
    {
        public int TripID { get; set; }
        public Trip Trip { get; set; }

        public int BidID { get; set; }
        public Bid Bid { get; set; }
    }
}
