using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurEverHomes.Models.Domain
{
    public class Pets
    {
        [Key]
        public int PetId { get; set; }
        public string PetName { get; set; } = "";
        public string PetSpecies { get; set; } = "";
        public string PetBreed { get; set; } = "";
        public string PetGender { get; set; } = "";
        public string PetHealthStatus { get; set; } = "";
        public int PetAge { get; set; }

        public int? AdopterId { get; set; } // Nullable if a pet might not have an adopter yet
        public int ShelterId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Adopters Adopter { get; set; }

        [JsonIgnore]
        public Shelter Shelter { get; set; }

    }
}
