using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Volvo.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessories",
                columns: table => new
                {
                    IdAcessory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessories", x => x.IdAcessory);
                });

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
                name: "AcessoryCategory",
                columns: table => new
                {
                    AcessoriesIdAcessory = table.Column<int>(type: "int", nullable: false),
                    CategoriesIdCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoryCategory", x => new { x.AcessoriesIdAcessory, x.CategoriesIdCategory });
                    table.ForeignKey(
                        name: "FK_AcessoryCategory_Acessories_AcessoriesIdAcessory",
                        column: x => x.AcessoriesIdAcessory,
                        principalTable: "Acessories",
                        principalColumn: "IdAcessory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcessoryCategory_Categories_CategoriesIdCategory",
                        column: x => x.CategoriesIdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
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
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "IdOwner");
                });

            migrationBuilder.CreateTable(
                name: "AcessoryCar",
                columns: table => new
                {
                    AcessoriesIdAcessory = table.Column<int>(type: "int", nullable: false),
                    CarsIdCar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoryCar", x => new { x.AcessoriesIdAcessory, x.CarsIdCar });
                    table.ForeignKey(
                        name: "FK_AcessoryCar_Acessories_AcessoriesIdAcessory",
                        column: x => x.AcessoriesIdAcessory,
                        principalTable: "Acessories",
                        principalColumn: "IdAcessory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcessoryCar_Cars_CarsIdCar",
                        column: x => x.CarsIdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AcessoryCar_CarsIdCar",
                table: "AcessoryCar",
                column: "CarsIdCar");

            migrationBuilder.CreateIndex(
                name: "IX_AcessoryCategory_CategoriesIdCategory",
                table: "AcessoryCategory",
                column: "CategoriesIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_AddressId",
                table: "Buyers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_ContactId",
                table: "Buyers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

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
                name: "AcessoryCar");

            migrationBuilder.DropTable(
                name: "AcessoryCategory");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Acessories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
