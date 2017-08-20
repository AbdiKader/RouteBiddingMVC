using Microsoft.AspNetCore.Mvc.Rendering;
using RouteBiddingMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.ViewModels
{
    public class AddDropOffViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]

        public int Zip { get; set; }
        [DataType(DataType.Time)]
        public DateTime Appointment { get; set; }
        [Required]
        public string Notes { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; }
    
        public List<SelectListItem> Customers { get; set; }
        public AddDropOffViewModel() { }

        public AddDropOffViewModel(IEnumerable<Customer> customers)
        {
            Customers = new List<SelectListItem>();
            foreach (var customer in customers) {
                Customers.Add(new SelectListItem
                {
                    Value = customer.ID.ToString(),
                    Text = customer.Name

                });

        } }
    }
}
