namespace FurEverHomes.Models.DTO
{
    public class AddAdopterRequestDto
    {
        public string AdopterFirstName { get; set; } = "";
        public string AdopterLastName { get; set; } = "";
        public string AdopterEmail { get; set; } = "";
        public string AdopterPhone { get; set; } = "";
        public string AdopterAddress { get; set; } = "";
    }
}
