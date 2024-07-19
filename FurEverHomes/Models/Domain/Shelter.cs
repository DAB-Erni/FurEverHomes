using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurEverHomes.Models.Domain
{
    public class Shelter
    {
        [Key]
        public int ShelterId { get; set; }
        public string ShelterName { get; set; } = "";
        public string ShelterEmail { get; set; } = "";
        public string ShelterPhone { get; set; } = "";
        public string ShelterAddress { get; set; } = "";

        [JsonIgnore]
        public ICollection<Application> Applications { get; set; } = new List<Application>();

        [JsonIgnore]
        public ICollection<Pets> Pets { get; set; } = new List<Pets>();

    }
}

