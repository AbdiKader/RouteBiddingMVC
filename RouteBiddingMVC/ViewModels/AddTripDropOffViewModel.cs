using Microsoft.AspNetCore.Mvc.Rendering;
using RouteBiddingMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.ViewModels
{
    public class AddTripDropOffViewModel
    {
        public Trip Trip { get; set; }
        public int TripID { get; set; }
        [Display(Name ="Select a customer")]
        public int DropOffID { get; set; }
        
        public List<SelectListItem> DropOffs { get; set; }
        public List<SelectListItem> Customers { get; set; }

        public AddTripDropOffViewModel() { }

        public AddTripDropOffViewModel(Trip trip, IEnumerable<DropOff> dropOffs, IEnumerable<Customer> customers)
        {
            Customers = new List<SelectListItem>();

            foreach(var customer in customers)
            {
                Customers.Add(new SelectListItem {
                    Value = customer.ID.ToString(),
                    Text = customer.Name
                });
            }

            DropOffs = new List<SelectListItem>();
            foreach(var dropOff in dropOffs)
            {
                DropOffs.Add(new SelectListItem
                {
                    Value = dropOff.ID.ToString(),
                    Text = dropOff.Name
                });
            }

            Trip = trip;
            TripID = trip.ID;
        }
    }
}
