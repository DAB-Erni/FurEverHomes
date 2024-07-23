//using FurEverHomes.Models.Domain;

//namespace FurEverHomes.Models.DTO
//{
//    public class ShelterDto
//    {
//        public int ShelterId { get; set; }
//        public string ShelterName { get; set; } = "";
//        public string ShelterEmail { get; set; } = "";
//        public string ShelterPhone { get; set; } = "";
//        public string ShelterAddress { get; set; } = "";

//        public ICollection<Application> Applications { get; set; } = new List<Application>();
//        public ICollection<Pets> Pets { get; set; } = new List<Pets>();
//    }
//}


namespace FurEverHomes.Models.DTO
{
    public class ShelterDto
    {
        public int ShelterId { get; set; }
        public string ShelterName { get; set; }
        public string ShelterEmail { get; set; }
        public string ShelterPhone { get; set; }
        public string ShelterAddress { get; set; }
        public List<int>? ApplicationIds { get; set; }
        public List<int>? PetIds { get; set; }
    }
}