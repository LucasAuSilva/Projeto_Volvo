// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Volvo.Api.Models;

#nullable disable

namespace Projeto_Volvo.Api.Migrations
{
    [DbContext(typeof(VolvoContext))]
    [Migration("20220209190155_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AcessoryCar", b =>
                {
                    b.Property<int>("AcessoriesIdAcessory")
                        .HasColumnType("int");

                    b.Property<int>("CarsIdCar")
                        .HasColumnType("int");

                    b.HasKey("AcessoriesIdAcessory", "CarsIdCar");

                    b.HasIndex("CarsIdCar");

                    b.ToTable("AcessoryCar");
                });

            modelBuilder.Entity("AcessoryCategory", b =>
                {
                    b.Property<int>("AcessoriesIdAcessory")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesIdCategory")
                        .HasColumnType("int");

                    b.HasKey("AcessoriesIdAcessory", "CategoriesIdCategory");

                    b.HasIndex("CategoriesIdCategory");

                    b.ToTable("AcessoryCategory");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Acessory", b =>
                {
                    b.Property<int>("IdAcessory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAcessory"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdAcessory");

                    b.ToTable("Acessories");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Address", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAddress"), 1L, 1);

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CodeCity")
                        .HasColumnType("int");

                    b.Property<int>("CodeState")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("State")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAddress");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Buyer", b =>
                {
                    b.Property<int>("IdBuyer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBuyer"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdBuyer");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCar"), 1L, 1);

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Kilometrage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumberChassis")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("VersionSystem")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdCar");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Contact", b =>
                {
                    b.Property<int>("IdContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContact"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Fax")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdContact");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Dealership", b =>
                {
                    b.Property<int>("IdDealership")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDealership"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdDealership");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("Dealerships");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Owner", b =>
                {
                    b.Property<int>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOwner"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdOwner");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSale"), 1L, 1);

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DealershipId")
                        .HasColumnType("int");

                    b.Property<float>("SaleValue")
                        .HasColumnType("real");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("IdSale");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CarId");

                    b.HasIndex("DealershipId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Worker", b =>
                {
                    b.Property<int>("IdWorker")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWorker"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<float>("BaseSalary")
                        .HasColumnType("real");

                    b.Property<float>("Commission")
                        .HasColumnType("real");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("DealershipId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IdWorker");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.HasIndex("DealershipId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("AcessoryCar", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Acessory", null)
                        .WithMany()
                        .HasForeignKey("AcessoriesIdAcessory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Volvo.Api.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsIdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessoryCategory", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Acessory", null)
                        .WithMany()
                        .HasForeignKey("AcessoriesIdAcessory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Volvo.Api.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesIdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Buyer", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Address", "Address")
                        .WithMany("Buyers")
                        .HasForeignKey("AddressId");

                    b.HasOne("Projeto_Volvo.Api.Models.Contact", "Contact")
                        .WithMany("Buyers")
                        .HasForeignKey("ContactId");

                    b.Navigation("Address");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Car", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Dealership", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Address", "Address")
                        .WithMany("Dealerships")
                        .HasForeignKey("AddressId");

                    b.HasOne("Projeto_Volvo.Api.Models.Contact", "Contact")
                        .WithMany("Dealerships")
                        .HasForeignKey("ContactId");

                    b.Navigation("Address");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Owner", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Address", "Address")
                        .WithMany("Owners")
                        .HasForeignKey("AddressId");

                    b.HasOne("Projeto_Volvo.Api.Models.Contact", "Contact")
                        .WithMany("Owners")
                        .HasForeignKey("ContactId");

                    b.Navigation("Address");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Sale", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Buyer", "Buyer")
                        .WithMany("Sales")
                        .HasForeignKey("BuyerId");

                    b.HasOne("Projeto_Volvo.Api.Models.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("CarId");

                    b.HasOne("Projeto_Volvo.Api.Models.Dealership", "Dealership")
                        .WithMany("Sales")
                        .HasForeignKey("DealershipId");

                    b.HasOne("Projeto_Volvo.Api.Models.Worker", "Worker")
                        .WithMany("Sales")
                        .HasForeignKey("WorkerId");

                    b.Navigation("Buyer");

                    b.Navigation("Car");

                    b.Navigation("Dealership");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Worker", b =>
                {
                    b.HasOne("Projeto_Volvo.Api.Models.Address", "Address")
                        .WithMany("Workers")
                        .HasForeignKey("AddressId");

                    b.HasOne("Projeto_Volvo.Api.Models.Contact", "Contact")
                        .WithMany("Workers")
                        .HasForeignKey("ContactId");

                    b.HasOne("Projeto_Volvo.Api.Models.Dealership", "Dealership")
                        .WithMany("Workers")
                        .HasForeignKey("DealershipId");

                    b.Navigation("Address");

                    b.Navigation("Contact");

                    b.Navigation("Dealership");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Address", b =>
                {
                    b.Navigation("Buyers");

                    b.Navigation("Dealerships");

                    b.Navigation("Owners");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Buyer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Car", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Contact", b =>
                {
                    b.Navigation("Buyers");

                    b.Navigation("Dealerships");

                    b.Navigation("Owners");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Dealership", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Projeto_Volvo.Api.Models.Worker", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
