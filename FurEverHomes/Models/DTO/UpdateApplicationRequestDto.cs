using System;

namespace FurEverHomes.Models.DTO
{
    public class UpdateApplicationRequestDto
    {
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = "";
        public int AdopterId { get; set; }
        public int ShelterId { get; set; }
        public int PetId { get; set; }
    }
}