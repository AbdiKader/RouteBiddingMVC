using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class DropOff//dropoff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        
        public string Notes { get; set; }

        public IList<TripDropOff> TripDropOffs{ get; set; }
        public Customer Customer { get; set; }//Customer
        public int CustomerID { get; set; }
    }
}




