using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RouteBiddingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteBiddingMVC.Data
{
    public class RouteBiddingDbContext: DbContext
    {
        public DbSet<BidType> BidTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DropOff> DropOffs { get; set; }
        public DbSet<Trip> Trips{ get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<TripBid> TripBids { get; set; }
        public DbSet<TripDropOff> TripDropOffs { get; set; }

       
        public RouteBiddingDbContext(DbContextOptions<RouteBiddingDbContext> options)
            :base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripBid>()
                .HasKey(c => new { c.TripID, c.BidID });

            modelBuilder.Entity<TripDropOff>()
                .HasKey(c => new { c.TripID, c.DropOffID });
        }

    }
}
