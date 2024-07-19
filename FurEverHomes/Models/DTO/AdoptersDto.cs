//using FurEverHomes.Models.Domain;

//namespace FurEverHomes.Models.DTO
//{
//    public class AdoptersDto
//    {
//        public int AdopterId { get; set; }
//        public string AdopterFirstName { get; set; } = "";
//        public string AdopterLastName { get; set; } = "";
//        public string AdopterEmail { get; set; } = "";
//        public string AdopterPhone { get; set; } = "";
//        public string AdopterAddress { get; set; } = "";

//        public ICollection<Application>? Applications { get; set; } = new List<Application>();
//        public ICollection<Pets>? Pets { get; set; } = new List<Pets>();
//    }
//}

namespace FurEverHomes.Models.DTO
{
    public class AdopterDto
    {
        public int AdopterId { get; set; }
        public string AdopterFirstName { get; set; } = "";
        public string AdopterLastName { get; set; } = "";
        public string AdopterEmail { get; set; } = "";
        public string AdopterPhone { get; set; } = "";
        public string AdopterAddress { get; set; } = "";
    }
}