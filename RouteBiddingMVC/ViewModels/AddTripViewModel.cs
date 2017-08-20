using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.ViewModels
{
    public class AddTripViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Time)]
        public DateTime Dispatch { get; set; }
        [Display(Name="Allocated Time")]
        public decimal AllocatedHours { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime Reuturn { get; set; }
        

       
    }
}
