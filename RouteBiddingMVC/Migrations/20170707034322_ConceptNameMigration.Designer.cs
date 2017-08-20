using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RouteBiddingMVC.Data;

namespace RouteBiddingMVC.Migrations
{
    [DbContext(typeof(RouteBiddingDbContext))]
    [Migration("20170707034322_ConceptNameMigration")]
    partial class ConceptNameMigration
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

            modelBuilder.Entity("RouteBiddingMVC.Models.RouteType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notation");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("RouteTypes");
                });
        }
    }
}
