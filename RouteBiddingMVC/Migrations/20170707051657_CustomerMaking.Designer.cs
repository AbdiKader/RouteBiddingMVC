using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RouteBiddingMVC.Data;

namespace RouteBiddingMVC.Migrations
{
    [DbContext(typeof(RouteBiddingDbContext))]
    [Migration("20170707051657_CustomerMaking")]
    partial class CustomerMaking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RouteBiddingMVC.Models.ConceptName", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Concept");

                    b.HasKey("ID");

                    b.ToTable("ConceptNames");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Appointment");

                    b.Property<string>("City");

                    b.Property<int?>("ConceptID");

                    b.Property<int>("CustomerID");

                    b.Property<string>("Notes");

                    b.Property<string>("State");

                    b.HasKey("ID");

                    b.HasIndex("ConceptID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.RouteType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notation");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("RouteTypes");
                });

            modelBuilder.Entity("RouteBiddingMVC.Models.Customer", b =>
                {
                    b.HasOne("RouteBiddingMVC.Models.ConceptName", "Concept")
                        .WithMany("Customers")
                        .HasForeignKey("ConceptID");
                });
        }
    }
}
