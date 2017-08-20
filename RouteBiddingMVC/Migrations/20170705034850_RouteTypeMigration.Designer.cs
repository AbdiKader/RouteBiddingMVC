using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RouteBiddingMVC.Data;

namespace RouteBiddingMVC.Migrations
{
    [DbContext(typeof(RouteBiddingDbContext))]
    [Migration("20170705034850_RouteTypeMigration")]
    partial class RouteTypeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RouteBiddingMVC.Models.RouteType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<char>("Notation");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("RouteTypes");
                });
        }
    }
}
