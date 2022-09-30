using AutoMapper;
using AdventureWorks2019BE.DTOs.SigeoDTOs;
using AdventureWorks2019BE.Entities.SigeoEntities;

namespace AdventureWorks2019BE.AutomapperEntityDto
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserDTO, User>()
            .ForMember(
                dest => dest._Id,
                opt => opt.MapFrom(src => $"{src._Id}")
            )
            .ForMember(
                dest => dest.Login,
                opt => opt.MapFrom(src => $"{src.Login}")
            )
            .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => $"{src.PasswordHash}")
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => $"{src.FirstName}")
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => $"{src.LastName}")
            )
            .ReverseMap();

        }
    }
}
