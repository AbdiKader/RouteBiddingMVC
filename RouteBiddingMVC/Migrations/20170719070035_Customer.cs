using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RouteBiddingMVC.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ConceptNames_ConceptID",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ConceptNames");

            migrationBuilder.DropTable(
                name: "RouteTypes");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ConceptID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Appointment",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConceptID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Customers",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "BidTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DropOffs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Appointment = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropOffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DropOffs_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllocatedHours = table.Column<decimal>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Dispatch = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pay = table.Column<decimal>(nullable: false),
                    Reuturn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BidTypeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_BidTypes_BidTypeID",
                        column: x => x.BidTypeID,
                        principalTable: "BidTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripDropOffs",
                columns: table => new
                {
                    TripID = table.Column<int>(nullable: false),
                    DropOffID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDropOffs", x => new { x.TripID, x.DropOffID });
                    table.ForeignKey(
                        name: "FK_TripDropOffs_DropOffs_DropOffID",
                        column: x => x.DropOffID,
                        principalTable: "DropOffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDropOffs_Trips_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripBids",
                columns: table => new
                {
                    TripID = table.Column<int>(nullable: false),
                    BidID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripBids", x => new { x.TripID, x.BidID });
                    table.ForeignKey(
                        name: "FK_TripBids_Bids_BidID",
                        column: x => x.BidID,
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripBids_Trips_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidTypeID",
                table: "Bids",
                column: "BidTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DropOffs_CustomerID",
                table: "DropOffs",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TripBids_BidID",
                table: "TripBids",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_TripDropOffs_DropOffID",
                table: "TripDropOffs",
                column: "DropOffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripBids");

            migrationBuilder.DropTable(
                name: "TripDropOffs");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "DropOffs");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "BidTypes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "State");

            migrationBuilder.AddColumn<DateTime>(
                name: "Appointment",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConceptID",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConceptNames",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Concept = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptNames", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RouteTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Notation = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ConceptID",
                table: "Customers",
                column: "ConceptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ConceptNames_ConceptID",
                table: "Customers",
                column: "ConceptID",
                principalTable: "ConceptNames",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
