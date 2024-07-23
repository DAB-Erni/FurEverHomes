//using FurEverHomes.Models.Domain;
//using System.Text.Json.Serialization;

//namespace FurEverHomes.Models.DTO
//{
//    public class ApplicationDto
//    {
//        public int ApplicationId { get; set; }
//        public DateTime ApplicationDate { get; set; }
//        public string Status { get; set; } = "";
//        public int AdopterId { get; set; }
//        public int ShelterId { get; set; }
//        public int? PetId { get; set; }

//        public Adopters? Adopter { get; set; }

//        public Shelter? Shelter { get; set; }

//        public ICollection<PetDto> Pets { get; set; } = new List<PetDto>();

//    }
//}

using System;
using System.Collections.Generic;

namespace FurEverHomes.Models.DTO
{
    public class ApplicationDto
    {
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }

        // Simplified representations of related entities
        public int? AdopterId { get; set; }
        //public int? ShelterId { get; set; }
        public int? PetId { get; set; }

        // Optionally include detailed DTOs for related entities
        public AdopterDto Adopter { get; set; }
        //public ShelterDto Shelter { get; set; }
        public PetDto Pet { get; set; }
    }
}
