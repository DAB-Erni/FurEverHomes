using System.ComponentModel.DataAnnotations;

namespace FurEverHomes.Models.Domain
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Status { get; set; } = "";
        //public int AdopterId { get; set; }
        //public int PetId { get; set; }
        //public int ShelterId { get; set; }

        // Navigation properties
        public Adopters Adopters { get; set; }
        public Shelter Shelter { get; set; }
        public Pets? Pets { get; set; }

    }
}

//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace FurEverHomes.Models.Domain
//{
//    public class Application
//    {
//        [Key]
//        public int Id { get; set; }

//        // Use DateTime instead of DateOnly
//        public DateTime Date { get; set; }

//        public string Status { get; set; } = "";

//        // Foreign key properties
//        public int AdoptersId { get; set; }
//        public int ShelterId { get; set; }
//        public int PetsId { get; set; }

//        // Navigation properties
//        [ForeignKey("AdoptersId")]
//        public Adopters Adopters { get; set; }

//        [ForeignKey("ShelterId")]
//        public Shelter Shelter { get; set; }

//        [ForeignKey("PetsId")]
//        public Pets Pets { get; set; }
//    }
//}