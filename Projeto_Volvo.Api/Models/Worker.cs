using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Volvo.Api.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int IdWorker { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }
        public float BaseSalary { get; set; }
        [MaxLength(15)]
        public string? Cpf { get; set; }
        public float Commission { get; set; }
        public int Level { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }
        [ForeignKey("DealershipId")]
        public virtual Dealership? Dealership { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
