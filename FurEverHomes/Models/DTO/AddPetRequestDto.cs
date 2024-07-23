namespace FurEverHomes.Models.DTO
{
    public class AddPetRequestDto
    {
        public string PetName { get; set; } = "";
        public string PetSpecies { get; set; } = "";
        public string PetBreed { get; set; } = "";
        public string PetGender { get; set; } = "";
        public string PetHealthStatus { get; set; } = "";
        public int PetAge { get; set; }
        //public int? ApplicationId { get; set; } // Nullable if a pet might not have an adopter yet
        public int ShelterId { get; set; }
    }
}