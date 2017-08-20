using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteBiddingMVC.Data;
using RouteBiddingMVC.Models;
using RouteBiddingMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RouteBiddingMVC.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        private readonly RouteBiddingDbContext context;

        public TripController(RouteBiddingDbContext dbContext)
        {
            context = dbContext;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
           var  trip =await  context.Trips.ToListAsync();
            return View(trip);
        }

        public IActionResult Add()
        {
            AddTripViewModel addTripViewModel = new AddTripViewModel();
            return View(addTripViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTripViewModel addTripViewModel)
        {
            if (ModelState.IsValid)
            {
                Trip newTrip = new Trip
                {
                    Name = addTripViewModel.Name,
                    AllocatedHours = addTripViewModel.AllocatedHours,
                    Day = addTripViewModel.Day,
                    Dispatch = addTripViewModel.Dispatch,
                    Reuturn = addTripViewModel.Reuturn,
                    Pay = (addTripViewModel.AllocatedHours) * 24,


                };

                context.Trips.Add(newTrip);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addTripViewModel);

        }

        public IActionResult DeleteTrip(int ?id)
        {
            Trip trip = context.Trips.SingleOrDefault(c => c.ID == id);
            return View(trip);
        }
        [HttpPost]
        public IActionResult DeleteTrip(int id)
        {
            Trip trip = context.Trips.SingleOrDefault(c => c.ID == id);
            context.Remove(trip);
            context.SaveChanges();
           return RedirectToAction("Index");
        }

        public IActionResult AddDropOff(int ? id)
        {
            Trip trip = context.Trips.Single(c => c.ID == id);
            List<DropOff> dropOffs = context.DropOffs.ToList();
            List<Customer> customers = context.Customers.ToList();
            return View(new AddTripDropOffViewModel(trip, dropOffs, customers));
        }

        [HttpPost]
        public IActionResult AddDropOff(AddTripDropOffViewModel addDropOffViewModel)
        {
            var dropOffID = addDropOffViewModel.DropOffID;
            var tripID = addDropOffViewModel.TripID;
            IList<TripDropOff> existingItem = context.TripDropOffs
                .Where(td => td.TripID == tripID)
                .Where(td => td.DropOffID == dropOffID).ToList();
            if (existingItem.Count == 0)
            {
                TripDropOff tripDropOff = new TripDropOff
                {
                    Trip = context.Trips.Single(tr => tr.ID == tripID),
                    DropOff = context.DropOffs.Single(dr => dr.ID == dropOffID)
                };
                context.TripDropOffs.Add(tripDropOff);
                context.SaveChanges();
                return Redirect(string.Format("/Trip/ViewTripDropOff/{0}", addDropOffViewModel.TripID));
            }
            return View("DuplicateAddError");
            
        }

        public IActionResult DeleteDropOff(int ? id)
        {
            
            TripDropOff del = context.TripDropOffs
                .Include(td => td.Trip)
                .Where(td => td.DropOffID == id).Single();
            return View(del);
        }

        [HttpPost]
        public IActionResult DeleteDropOff(TripDropOff tripDropOff)
        {

            
                return RedirectToAction("ViewTripDropOff");
        }

        [AllowAnonymous]
        public IActionResult ViewTripDropOff(int id)
        {
            List<TripDropOff> stops = context.
                TripDropOffs.Include(tr => tr.DropOff)
                .Where(c => c.TripID == id).ToList();
            Trip trip = context.Trips.Single(c => c.ID == id);
            ViewDropOffViewModel viewDropOffViewModel = new ViewDropOffViewModel
            {
                Trip = trip,
                Stops = stops
            };
            return View(viewDropOffViewModel);
        }

    
    }
}