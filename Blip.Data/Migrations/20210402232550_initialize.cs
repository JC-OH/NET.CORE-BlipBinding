using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blip.Data.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Iso3 = table.Column<string>(maxLength: 3, nullable: false),
                    CountryNameEnglish = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Iso3);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    ReorderQuantity = table.Column<int>(nullable: false),
                    MSRP = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionCode = table.Column<string>(maxLength: 3, nullable: false),
                    Iso3 = table.Column<string>(maxLength: 3, nullable: false),
                    RegionNameEnglish = table.Column<string>(nullable: false),
                    CountryIso3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionCode);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryIso3",
                        column: x => x.CountryIso3,
                        principalTable: "Countries",
                        principalColumn: "Iso3",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 128, nullable: false),
                    CountryIso3 = table.Column<string>(maxLength: 3, nullable: false),
                    RegionCode = table.Column<string>(maxLength: 3, nullable: true),
                    RegionCode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryIso3",
                        column: x => x.CountryIso3,
                        principalTable: "Countries",
                        principalColumn: "Iso3",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Regions_RegionCode1",
                        column: x => x.RegionCode1,
                        principalTable: "Regions",
                        principalColumn: "RegionCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.ItemID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryIso3",
                table: "Customers",
                column: "CountryIso3");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RegionCode1",
                table: "Customers",
                column: "RegionCode1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryIso3",
                table: "Regions",
                column: "CountryIso3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
