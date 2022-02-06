using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto_Volvo.Api.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Buyers = new HashSet<Buyer>();
            Dealerships = new HashSet<Dealership>();
            Owners = new HashSet<Owner>();
            Workers = new HashSet<Worker>();
        }

        [Key]
        public int IdContact { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(20)]
        public string? Fax { get; set; }
        [MaxLength(40)]
        public string? Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Buyer> Buyers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Dealership> Dealerships { get; set; }
        [JsonIgnore]
        public virtual ICollection<Owner> Owners { get; set; }
        [JsonIgnore]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
