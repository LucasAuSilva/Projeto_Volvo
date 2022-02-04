using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Curso_Volvo.Api.Models
{
    public partial class Acessory
    {
        public Acessory()
        {
            AcessoriesCategories = new HashSet<AcessoriesCategory>();
            Cars = new HashSet<Car>();
        }

        [Key]
        public int IdAcessory { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public virtual ICollection<AcessoriesCategory> AcessoriesCategories { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
