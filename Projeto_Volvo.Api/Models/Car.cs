using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Volvo.Api.Models
{
    public partial class Car
    {
        public Car()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int IdCar { get; set; }
        public int Kilometrage { get; set; }
        public int Year { get; set; }
        [MaxLength(10)]
        public string? NumberChassis { get; set; }
        [MaxLength(20)]
        public string? Color { get; set; }
        public float Price { get; set; }
        [MaxLength(50)]
        public string? Model { get; set; }
        [MaxLength(20)]
        public string? VersionSystem { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Owner? Owner { get; set; }

        [ForeignKey("AcessoryId")]
        public virtual Acessory? Acessorie { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
