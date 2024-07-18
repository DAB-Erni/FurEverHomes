using System.ComponentModel.DataAnnotations;

namespace FurEverHomes.Models.Domain
{
    public class Pets
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Species { get; set; } = "";
        public string Breed { get; set; } = "";
        public string Gender { get; set; } = "";
        public string HealthStatus { get; set; } = "";
        public int Age { get; set; }
        //public int AdopterId { get; set; }
        //public int ShelterId { get; set; }

        // Navigation properties
        public Adopters Adopters { get; set; }
        public Shelter Shelter { get; set; }

    }
}

//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace FurEverHomes.Models.Domain
//{
//    public class Pets
//    {
//        [Key]
//        public int Id { get; set; }
//        public string Name { get; set; } = "";
//        public string Species { get; set; } = "";
//        public string Breed { get; set; } = "";
//        public string Gender { get; set; } = "";
//        public string HealthStatus { get; set; } = "";
//        public int Age { get; set; }

//        // Foreign keys
//        public int AdoptersId { get; set; }
//        public int ShelterId { get; set; }

//        // Navigation properties
//        public Adopters Adopters { get; set; }
//        public Shelter Shelter { get; set; }
//    }
//}