using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteBiddingMVC.Data;
using RouteBiddingMVC.Models;
using RouteBiddingMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace RouteBiddingMVC.Models
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly RouteBiddingDbContext context;


        public CustomerController(RouteBiddingDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Customer> customer = context.Customers.ToList();
            return View(customer);
        }

        public IActionResult Add()
        {
            AddCustomerViewModel CustomerViewModel = new AddCustomerViewModel();
            return View(CustomerViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCustomerViewModel CustomerViewModel)
        {
            Customer newcustomer = new Customer();
            if (ModelState.IsValid)
            {
                newcustomer = new Customer
                {
                    Name= CustomerViewModel.Name
                };
                context.Customers.Add(newcustomer);
                context.SaveChanges();
                return Redirect("Index");
            }
            return View(CustomerViewModel);
        }

        public IActionResult Edit(int ? id)
        {
            AddCustomerViewModel CustomerViewModel = new AddCustomerViewModel();
            return View(CustomerViewModel);

        }
        [HttpPost]
        public IActionResult Edit(int id, AddCustomerViewModel customerViewModel)
        {
            Customer customerToEdit = context.Customers.Single(c => c.ID == id);

            if (ModelState.IsValid)
            {
                customerToEdit.Name = customerViewModel.Name;
                context.Customers.Update(customerToEdit);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerViewModel);

        }

        public IActionResult Delete(int ? id)
        {
            Customer customerToDelete = context.Customers.Single(c => c.ID == id);
            return View(customerToDelete);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Customer customerToDelete = context.Customers.Single(c => c.ID == id);
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");

        } 

    }
}