using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Volvo.Api.Models
{
    public partial class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }
        [MaxLength(15)]
        public string? Cpf { get; set; }
        [MaxLength(20)]
        public string? Cnpj { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }
    }
}
