using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Curso_Volvo.Api.Models
{
    public partial class AcessoriesCategory
    {
        [Key]
        public int IdAcessoriesCategory { get; set; }
        [ForeignKey("AcessoryId")]
        public virtual Acessory? Acessorie { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
