using AutoMapper;
using MyVaccine.WebApi.DTOs.Request;
using MyVaccine.WebApi.DTOs.Response;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DependentRequestDTO, Dependent>();
        CreateMap<Dependent, DependentResponseDTO>()
            .ForMember(
                dest => dest.UserFullName, 
                opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

        CreateMap<AllergyRequestDTO, Allergy>();
        CreateMap<Allergy, AllergyResponseDTO>()
            .ForMember(
                dest => dest.UserFullName, 
                opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
    }
}
