using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Curso_Volvo.Models
{
    public partial class Dealership
    {
        public Dealership()
        {
            Sales = new HashSet<Sale>();
            Workers = new HashSet<Worker>();
        }

        [Key]
        public int IdDealership { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }
        [MaxLength(20)]
        public string? Cnpj { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
