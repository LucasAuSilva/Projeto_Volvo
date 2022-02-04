using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Curso_Volvo.Api.Models
{
    public partial class Category
    {
        public Category()
        {
            Acessories = new HashSet<Acessory>();
            AcessoriesCategories = new HashSet<AcessoriesCategory>();
        }

        [Key]
        public int IdCategory { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }

        public virtual ICollection<Acessory> Acessories { get; set; }
        public virtual ICollection<AcessoriesCategory> AcessoriesCategories { get; set; }
    }
}
