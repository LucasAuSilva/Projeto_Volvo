using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Volvo.Api.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodeCity = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CodeState = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.IdAddress);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.IdContact);
                });

            migrationBuilder.CreateTable(
                name: "Acessories",
                columns: table => new
                {
                    IdAcessory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessories", x => x.IdAcessory);
                    table.ForeignKey(
                        name: "FK_Acessories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    IdBuyer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.IdBuyer);
                    table.ForeignKey(
                        name: "FK_Buyers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress");
                    table.ForeignKey(
                        name: "FK_Buyers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "IdContact");
                });

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    IdDealership = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.IdDealership);
                    table.ForeignKey(
                        name: "FK_Dealerships_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress");
                    table.ForeignKey(
                        name: "FK_Dealerships_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "IdContact");
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    IdOwner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.IdOwner);
                    table.ForeignKey(
                        name: "FK_Owners_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress");
                    table.ForeignKey(
                        name: "FK_Owners_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "IdContact");
                });

            migrationBuilder.CreateTable(
                name: "AcessoriesCategories",
                columns: table => new
                {
                    IdAcessoriesCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcessoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoriesCategories", x => x.IdAcessoriesCategory);
                    table.ForeignKey(
                        name: "FK_AcessoriesCategories_Acessories_AcessoryId",
                        column: x => x.AcessoryId,
                        principalTable: "Acessories",
                        principalColumn: "IdAcessory");
                    table.ForeignKey(
                        name: "FK_AcessoriesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilometrage = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    NumberChassis = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VersionSystem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AcessoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_Acessories_AcessoryId",
                        column: x => x.AcessoryId,
                        principalTable: "Acessories",
                        principalColumn: "IdAcessory");
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IdWorker = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    BaseSalary = table.Column<float>(type: "real", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Commission = table.Column<float>(type: "real", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    DealershipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IdWorker);
                    table.ForeignKey(
                        name: "FK_Workers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress");
                    table.ForeignKey(
                        name: "FK_Workers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "IdContact");
                    table.ForeignKey(
                        name: "FK_Workers_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "IdDealership");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleValue = table.Column<float>(type: "real", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    DealershipId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sales_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "IdBuyer");
                    table.ForeignKey(
                        name: "FK_Sales_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "IdCar");
                    table.ForeignKey(
                        name: "FK_Sales_Dealerships_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "Dealerships",
                        principalColumn: "IdDealership");
                    table.ForeignKey(
                        name: "FK_Sales_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "IdWorker");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessories_CategoryId",
                table: "Acessories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AcessoriesCategories_AcessoryId",
                table: "AcessoriesCategories",
                column: "AcessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AcessoriesCategories_CategoryId",
                table: "AcessoriesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_AddressId",
                table: "Buyers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_ContactId",
                table: "Buyers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AcessoryId",
                table: "Cars",
                column: "AcessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_AddressId",
                table: "Dealerships",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_ContactId",
                table: "Dealerships",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ContactId",
                table: "Owners",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerId",
                table: "Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DealershipId",
                table: "Sales",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WorkerId",
                table: "Sales",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_AddressId",
                table: "Workers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ContactId",
                table: "Workers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DealershipId",
                table: "Workers",
                column: "DealershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoriesCategories");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Acessories");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
