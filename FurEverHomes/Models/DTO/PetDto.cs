﻿//using FurEverHomes.Models.Domain;
//using System.Text.Json.Serialization;

//namespace FurEverHomes.Models.DTO
//{
//    public class PetDto
//    {
//        public int PetId { get; set; }
//        public string PetName { get; set; } = "";
//        public string PetSpecies { get; set; } = "";
//        public string PetBreed { get; set; } = "";
//        public string PetGender { get; set; } = "";
//        public string PetHealthStatus { get; set; } = "";
//        public int PetAge { get; set; }

//        public int? AdopterId { get; set; } // Nullable if a pet might not have an adopter yet
//        public int ShelterId { get; set; }

//        // Navigation properties
//        public Adopters? Adopter { get; set; }

//        public Shelter? Shelter { get; set; }
//    }
//}

namespace FurEverHomes.Models.DTO
{
    public class PetDto
    {
        public int PetId { get; set; }
        public string PetName { get; set; } = "";
        public string PetSpecies { get; set; } = "";
        public string PetBreed { get; set; } = "";
        public string PetGender { get; set; } = "";
        public string PetHealthStatus { get; set; } = "";
        public int PetAge { get; set; }
    }
}