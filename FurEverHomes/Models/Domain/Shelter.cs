using System.ComponentModel.DataAnnotations;

namespace FurEverHomes.Models.Domain
{
    public class Shelter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}

