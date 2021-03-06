using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto_Volvo.Api.Models
{
    public partial class Address
    {
        public Address()
        {
            Buyers = new HashSet<Buyer>();
            Dealerships = new HashSet<Dealership>();
            Owners = new HashSet<Owner>();
            Workers = new HashSet<Worker>();
        }

        [Key]
        public int IdAddress { get; set; }
        [MaxLength(50)]
        public string? Street { get; set; }
        [MaxLength(30)]
        public string? District { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        public int CodeCity { get; set; }
        [MaxLength(30)]
        public string? State { get; set; }
        public int CodeState { get; set; }
        [MaxLength(10)]
        public string? Cep { get; set; }

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
