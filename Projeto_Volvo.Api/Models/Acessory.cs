﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto_Volvo.Api.Models
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
        [JsonIgnore]
        public virtual ICollection<AcessoriesCategory> AcessoriesCategories { get; set; }
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
    }
}
