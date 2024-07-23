using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FurEverHomes.Models.Domain
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = "";
        public int? AdopterId { get; set; }
        //public int? ShelterId { get; set; }

        public int? PetId { get; set; }

        [JsonIgnore]
        public Adopter? Adopter { get; set; }


        [JsonIgnore]
        public Pet Pet { get; set; }
    }
}