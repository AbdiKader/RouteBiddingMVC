using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteBiddingMVC.Data;
using RouteBiddingMVC.Models;
using RouteBiddingMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Controllers
{
    [Authorize]
    public class BidTypeController: Controller
       
    {
        private readonly RouteBiddingDbContext context;

        public BidTypeController(RouteBiddingDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()

        {
            List<BidType> routeType = context.BidTypes.ToList();
            return View(routeType);
        }

        public IActionResult Add()
        {
            AddBidTypeViewModel bidTypeViewModel = new AddBidTypeViewModel();
            return View(bidTypeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddBidTypeViewModel bidTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                BidType routeType = new BidType
                {
                    Name = bidTypeViewModel.Name,
                    
                };
                context.BidTypes.Add(routeType);
                context.SaveChanges();
                return Redirect("/");
            }
            return View(bidTypeViewModel);
        }

        
        public IActionResult Edit(int? id)
        {
            AddBidTypeViewModel bidTypeViewModel = new AddBidTypeViewModel();
            return View(bidTypeViewModel);
        }
        [HttpPost]
        public IActionResult Edit(AddBidTypeViewModel bidTypeViewModel, int id)
        {
           BidType bidType = context.BidTypes.Single(c => c.ID == id);
           
            if (ModelState.IsValid)
            {
                bidType.Name = bidTypeViewModel.Name;
                
              

                context.BidTypes.Update(bidType);
                context.SaveChanges();
                return Redirect("/");
            }

            return View(bidTypeViewModel);

        }

        public IActionResult Delete(int ? id)
        {
            BidType bidTypeToDelete = context.BidTypes.Single(m => m.ID == id);
            return View(bidTypeToDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            BidType bidTypeToDelete = context.BidTypes.Single(m => m.ID == id);
            context.BidTypes.Remove(bidTypeToDelete);
            context.SaveChanges();

            return Redirect("/");
        }
    }
}
