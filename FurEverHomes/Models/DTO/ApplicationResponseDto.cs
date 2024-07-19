namespace FurEverHomes.Models.DTO
{
    public class ApplicationResponseDto
    {
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public AdopterDto Adopter { get; set; }
        public ShelterDto Shelter { get; set; }
        public PetDto Pet { get; set; }
    }
}