using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class Bid
    {
        public int ID { get; set; }
        public string Name{ get; set; }

        public int BidTypeID { get; set; }
        public BidType BidType { get; set; }
        public IList<TripBid> TripBid { get; set; }
        
    }
}
/*
 TODO
 * driver bidded
 * detail button/bid/release bid/ unavailable
 */
