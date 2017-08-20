using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RouteBiddingMVC.Data;

namespace RouteBiddingMVC.Migrations
{
    [DbContext(typeof(RouteBiddingDbContext))]
    [Migration("20170818061423_users")]
    partial class users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RouteBiddingMVC.Models.Bid", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BidTypeID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("BidTypeID");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.BidType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("BidTypes");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.DropOff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int>("CustomerID");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("DropOffs");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AllocatedHours");

                    b.Property<int>("Day");

                    b.Property<DateTime>("Dispatch");

                    b.Property<string>("Name");

                    b.Property<decimal>("Pay");

                    b.Property<DateTime>("Reuturn");

                    b.HasKey("ID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.TripBid", b =>
                {
                    b.Property<int>("TripID");

                    b.Property<int>("BidID");

                    b.HasKey("TripID", "BidID");

                    b.HasIndex("BidID");

                    b.ToTable("TripBids");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.TripDropOff", b =>
                {
                    b.Property<int>("TripID");

                    b.Property<int>("DropOffID");

                    b.Property<DateTime>("Appointment");

                    b.HasKey("TripID", "DropOffID");

                    b.HasIndex("DropOffID");

                    b.ToTable("TripDropOffs");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.Bid", b =>
                {
                    b.HasOne("RouteBiddingMVC.Models.BidType", "BidType")
                        .WithMany("Bids")
                        .HasForeignKey("BidTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.DropOff", b =>
                {
                    b.HasOne("RouteBiddingMVC.Models.Customer", "Customer")
                        .WithMany("DropOffs")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.TripBid", b =>
                {
                    b.HasOne("RouteBiddingMVC.Models.Bid", "Bid")
                        .WithMany("TripBid")
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RouteBiddingMVC.Models.Trip", "Trip")
                        .WithMany("TripBid")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.TripDropOff", b =>
                {
                    b.HasOne("RouteBiddingMVC.Models.DropOff", "DropOff")
                        .WithMany("TripDropOffs")
                        .HasForeignKey("DropOffID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RouteBiddingMVC.Models.Trip", "Trip")
                        .WithMany("TripDropOffs")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
