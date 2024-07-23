//using AutoMapper;
//using FurEverHomes.Models;
//using FurEverHomes.Models.Domain;
//using FurEverHomes.Models.DTO;

//namespace FurEverHomes.Mappings
//{
//    public class DtoMapping : Profile
//    {
//        public DtoMapping()
//        {
//            // Maps
//            // Source => Destination
//            CreateMap<AddAdopterRequestDto, Adopters>();
//            CreateMap<UpdateAdopterDto, Adopters>();
//            CreateMap<Adopters, AdopterDto>();
//            CreateMap<Shelter, ShelterDto>();
//            CreateMap<Pets, PetDto>();

//            // New mapping for Application
//            CreateMap<AddApplicationRequestDto, Application>();
//            CreateMap<UpdateApplicationRequestDto, Application>();

//            // New mappings for nested data
//            CreateMap<Application, ApplicationDto>()
//                .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
//                .ForMember(dest => dest.Shelter, opt => opt.MapFrom(src => src.Shelter))
//                .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.Pet));
//        }
//    }
//}

//using AutoMapper;
//using FurEverHomes.Models;
//using FurEverHomes.Models.Domain;
//using FurEverHomes.Models.DTO;

//namespace FurEverHomes.Mappings
//{
//    public class DtoMapping : Profile
//    {
//        public DtoMapping()
//        {
//            // Adopter mappings
//            CreateMap<AddAdopterRequestDto, Adopter>();
//            CreateMap<UpdateAdopterDto, Adopter>();
//            CreateMap<Adopter, AdopterDto>()
//                .ForMember(dest => dest.ApplicationIds, opt => opt.MapFrom(src => src.Applications.Select(a => a.ApplicationId).ToList()));

//            // Shelter mappings
//            CreateMap<Shelter, ShelterDto>()
//                .ForMember(dest => dest.ApplicationIds, opt => opt.MapFrom(src => src.Applications.Select(a => a.ApplicationId).ToList()))
//                .ForMember(dest => dest.PetIds, opt => opt.MapFrom(src => src.Pets.Select(p => p.PetId).ToList()));
//            CreateMap<AddShelterRequestDto, Shelter>();

//            // Pet mappings
//            CreateMap<Pet, PetDto>()
//                .ForMember(dest => dest.ApplicationIds, opt => opt.MapFrom(src => src.Application.Select(a => a.ApplicationId).ToList()));
//            CreateMap<AddPetRequestDto, Pet>(); // Assuming you have an AddPetRequestDto

//            // Application mappings
//            CreateMap<AddApplicationRequestDto, Application>();
//            CreateMap<UpdateApplicationRequestDto, Application>();
//            CreateMap<Application, ApplicationDto>()
//                .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
//                .ForMember(dest => dest.Shelter, opt => opt.MapFrom(src => src.Shelter))
//                .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.Pet))
//                .ForMember(dest => dest.AdopterId, opt => opt.MapFrom(src => src.AdopterId))
//                .ForMember(dest => dest.ShelterId, opt => opt.MapFrom(src => src.ShelterId))
//                .ForMember(dest => dest.PetId, opt => opt.MapFrom(src => src.PetId));
//        }
//    }
//}

using AutoMapper;
using FurEverHomes.Models;
using FurEverHomes.Models.Domain;
using FurEverHomes.Models.DTO;
using System.Linq;

namespace FurEverHomes.Mappings
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            // Adopter mappings
            CreateMap<AddAdopterRequestDto, Adopter>();
            CreateMap<UpdateAdopterDto, Adopter>();
            CreateMap<Adopter, AdopterDto>()
                .ForMember(dest => dest.ApplicationIds, opt => opt.MapFrom(src => src.Applications.Select(a => a.ApplicationId).ToList()));

            // Shelter mappings
            CreateMap<Shelter, ShelterDto>()
                .ForMember(dest => dest.ApplicationIds, opt => opt.MapFrom(src => src.Applications.Select(a => a.ApplicationId).ToList()))
                .ForMember(dest => dest.PetIds, opt => opt.MapFrom(src => src.Pets.Select(p => p.PetId).ToList()));
            CreateMap<AddShelterRequestDto, Shelter>();
            CreateMap<UpdateShelterDto, Shelter>();

            // Pet mappings
            CreateMap<Pet, PetDto>()
                 .ForMember(dest => dest.ApplicationIds, opt => opt.MapFrom(src => src.Applications.Select(a => a.ApplicationId).ToList()))
                 .ForMember(dest => dest.ShelterId, opt => opt.MapFrom(src => src.ShelterId));
            CreateMap<AddPetRequestDto, Pet>();
            CreateMap<UpdatePetDto, Pet>();

            // Application mappings
            CreateMap<AddApplicationRequestDto, Application>();
            CreateMap<UpdateApplicationRequestDto, Application>();
            CreateMap<Application, ApplicationDto>()
                .ForMember(dest => dest.Adopter, opt => opt.MapFrom(src => src.Adopter))
                .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.Pet))
                .ForMember(dest => dest.AdopterId, opt => opt.MapFrom(src => src.AdopterId))
                //.ForMember(dest => dest.ShelterId, opt => opt.MapFrom(src => src.ShelterId))
                .ForMember(dest => dest.PetId, opt => opt.MapFrom(src => src.PetId));
        }
    }
}