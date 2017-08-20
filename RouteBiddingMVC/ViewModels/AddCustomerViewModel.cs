using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required]
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
