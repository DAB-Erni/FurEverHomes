using AutoMapper;
using FurEverHomes.Models;
using FurEverHomes.Models.Domain;
using FurEverHomes.Models.DTO;

namespace FurEverHomes.Mappings
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            // Maps
            // Source => Destination
            CreateMap<AddAdopterRequestDto, Adopters>();
            CreateMap<UpdateAdopterDto, Adopters>();
            CreateMap<Adopters, AdopterDto>();
            CreateMap<Shelter, ShelterDto>();
            CreateMap<Pets, PetDto>();

            // New mapping for Application
            CreateMap<AddApplicationRequestDto, Application>();
            CreateMap<UpdateApplicationRequestDto, Application>();

            // New mappings for nested data
            CreateMap<Application, ApplicationDto>()
                .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
                .ForMember(dest => dest.Shelter, opt => opt.MapFrom(src => src.Shelter))
                .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.Pet));
        }
    }
}