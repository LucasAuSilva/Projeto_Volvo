using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Curso_Volvo.Api.Models
{
    public partial class Sale
    {
        [Key]
        public int IdSale { get; set; }
        public DateTime Data { get; set; }
        public float SaleValue { get; set; }
        [ForeignKey("BuyerId")]
        public virtual Buyer? Buyer { get; set; }
        [ForeignKey("CarId")]
        public virtual Car? Car { get; set; }
        [ForeignKey("DealershipId")]
        public virtual Dealership? Dealership { get; set; }
        [ForeignKey("WorkerId")]
        public virtual Worker? Worker { get; set; }
    }
}
