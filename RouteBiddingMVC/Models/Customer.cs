using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class Customer//Customer
    {
        public int ID{ get; set; }
        public string Name { get; set; }

        public IList<DropOff> DropOffs { get; set; }//dropoff
    }
}
