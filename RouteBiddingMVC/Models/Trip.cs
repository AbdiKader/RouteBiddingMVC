using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Dispatch { get; set; }
        public decimal AllocatedHours{ get; set; }
        public DayOfWeek Day{ get; set; }
        public DateTime Reuturn { get; set; }
        public decimal Pay { get; set; }


        public IList<TripDropOff> TripDropOffs { get; set; }
        public IList<TripBid> TripBid { get; set; }

    }
}
/* create new model named TRIP 
 * PROPS 
 * id
 * appointment
 * concept / customer %selected from a dropdown
 * location % selected from a dropdown that is based on CONCEPT
 * allocated time
 * depart time 
 * depart day
 * return day
 * return time
 * pay
 * type of trip team/solo/layover
 */

/*Create a new model named BID
 * PROPS
 * id 
 * trips %selected from a drop down TRIPS
 * pay total
 * driver bidded
 * detail button/bid/release bid/ unavailable
 */
