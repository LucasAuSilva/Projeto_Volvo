using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto_Volvo.Api.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int IdBuyer { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }
        [MaxLength(15)]
        public string? Cpf { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
