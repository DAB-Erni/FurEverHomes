using System.ComponentModel.DataAnnotations;

namespace FurEverHomes.Models.Domain
{
    public class Adopters
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}

//using System.ComponentModel.DataAnnotations;

//namespace FurEverHomes.Models.Domain
//{
//    public class Adopters
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string FirstName { get; set; } = "";

//        [Required]
//        [MaxLength(100)]
//        public string LastName { get; set; } = "";

//        [Required]
//        [EmailAddress]
//        [MaxLength(100)]
//        public string Email { get; set; } = "";

//        [Required]
//        [Phone]
//        [MaxLength(15)]
//        public string Phone { get; set; } = "";

//        [Required]
//        [MaxLength(200)]
//        public string Address { get; set; } = "";

//        // Navigation properties
//        public ICollection<Application> Applications { get; set; }
//    }
//}