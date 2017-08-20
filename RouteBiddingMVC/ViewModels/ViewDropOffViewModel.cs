using RouteBiddingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.ViewModels
{
    public class ViewDropOffViewModel
    {
        public Trip Trip { get; set; }
        public IList<TripDropOff> Stops { get; set; }
    }
}
