using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto_Volvo.Api.Models
{
    public partial class Category
    {
        public Category()
        {
            Acessories = new HashSet<Acessory>();
        }

        [Key]
        public int IdCategory { get; set; }
        [MaxLength(80)]
        public string? Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Acessory> Acessories { get; set; }
    }
}
