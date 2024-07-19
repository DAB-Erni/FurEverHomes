using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurEverHomes.Models.Domain
{
    public class Adopters
    {
        [Key]
        public int AdopterId { get; set; }
        public string AdopterFirstName { get; set; } = "";
        public string AdopterLastName { get; set; } = "";
        public string AdopterEmail { get; set; } = "";
        public string AdopterPhone { get; set; } = "";
        public string AdopterAddress { get; set; } = "";

        [JsonIgnore]
        public ICollection<Application> Applications { get; set; } = new List<Application>();

        [JsonIgnore]
        public ICollection<Pets> Pets { get; set; } = new List<Pets>();
    }
}
