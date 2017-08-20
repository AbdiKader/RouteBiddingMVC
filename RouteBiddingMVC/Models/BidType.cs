using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class BidType
    {
 
        public int ID{ get; set; }
        public string Name { get; set; }

        public IList<Bid> Bids{ get; set; }
    }
}
