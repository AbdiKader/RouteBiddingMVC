using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteBiddingMVC.Data;
using RouteBiddingMVC.Models;
using Microsoft.EntityFrameworkCore;
using RouteBiddingMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace RouteBiddingMVC.Controllers
{
    [Authorize]
    public class DropOffController : Controller
    {
        private readonly RouteBiddingDbContext context;

        public DropOffController(RouteBiddingDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<DropOff> dropOff = context.DropOffs.Include(c=>c.Customer).ToList();
            return View(dropOff);
        }

        public IActionResult Add()
        {
            AddDropOffViewModel customerViewModel = new AddDropOffViewModel(context.Customers.ToList());

            return View(customerViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddDropOffViewModel addDropOffViewModel)
        {
            Customer customer = context.Customers.Single(c => c.ID == addDropOffViewModel.CustomerID);
            if (ModelState.IsValid)
            {
                DropOff newDropOff = new DropOff
                {
                    Name = addDropOffViewModel.Name,
                    Address = addDropOffViewModel.Address,
                    City = addDropOffViewModel.City,
                    State = addDropOffViewModel.State,
                    Zip = addDropOffViewModel.Zip,
                    Notes = addDropOffViewModel.Notes,
                    
                    Customer = customer

                };
                context.DropOffs.Add(newDropOff);
                context.SaveChanges();
                return Redirect("Index");
            }
            return View(addDropOffViewModel);
        }

        public IActionResult Edit(int ? id)
        {
            
            AddDropOffViewModel edit = new AddDropOffViewModel(context.Customers.ToList());
            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(int id, AddDropOffViewModel addDropOffViewModel)
        {
            DropOff stopToEdit = context.DropOffs.Single(c => c.ID == id);

            if (ModelState.IsValid)
            {
                stopToEdit.Name = addDropOffViewModel.Name;
                stopToEdit.Address = addDropOffViewModel.Address;
                stopToEdit.Zip = addDropOffViewModel.Zip;
                stopToEdit.Notes = addDropOffViewModel.Notes;
                
                context.DropOffs.Update(stopToEdit);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addDropOffViewModel);
        }
        public IActionResult Delete(int? id)
        {
            DropOff stopToDelete = context.DropOffs.Single(c => c.ID == id);
            return View(stopToDelete);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            DropOff stopToDelete = context.DropOffs.Single(c => c.ID == id);
            context.DropOffs.Remove(stopToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}