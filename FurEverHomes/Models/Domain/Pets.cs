using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurEverHomes.Models.Domain
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string PetName { get; set; } = "";
        public string PetSpecies { get; set; } = "";
        public string PetBreed { get; set; } = "";
        public string PetGender { get; set; } = "";
        public string PetHealthStatus { get; set; } = "";
        public int PetAge { get; set; }
        
        public int ShelterId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public List<Application> Applications { get; set; } = new List<Application>();

        [JsonIgnore]
        public Shelter? Shelter { get; set; }
    }
}