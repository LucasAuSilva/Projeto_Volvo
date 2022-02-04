using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Projeto_Curso_Volvo.Api.Models
{
    public partial class VolvoContext : DbContext
    {
        public VolvoContext(IConfiguration config)
        {
            _config = config;
        }

        public VolvoContext(DbContextOptions<VolvoContext> options)
            : base(options)
        {
        }

        private readonly IConfiguration _config;
        public virtual DbSet<AcessoriesCategory> AcessoriesCategories
        { get; set; } = null!;
        public virtual DbSet<Acessory> Acessories { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Dealership> Dealerships { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetValue<string>("DbConnection"));
            }
        }

    }
}
