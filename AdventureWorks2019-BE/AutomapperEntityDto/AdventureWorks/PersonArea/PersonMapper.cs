using AdventureWorks2019BE.Data;
using AdventureWorks2019BE.DTOs.AdventureWorks.PersonArea;
using AutoMapper;

namespace AdventureWorks2019BE.AutomapperEntityDto.AdventureWorks.PersonArea
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            #region PersonDTO
            CreateMap<PersonDTO, Person>()
            .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => $"{src.BusinessEntityID}"))
            .ForMember(dest => dest.PersonType, opt => opt.MapFrom(src => $"{src.PersonType}"))
            .ForMember(dest => dest.NameStyle, opt => opt.MapFrom(src => $"{src.NameStyle}"))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => $"{src.Title}"))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => $"{src.FirstName}"))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => $"{src.MiddleName}"))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => $"{src.LastName}"))
            .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => $"{src.Suffix}"))
            .ForMember(dest => dest.EmailPromotion, opt => opt.MapFrom(src => $"{src.EmailPromotion}"))
            .ForMember(dest => dest.AdditionalContactInfo, opt => opt.MapFrom(src => $"{src.AdditionalContactInfo}"))
            .ForMember(dest => dest.Demographics, opt => opt.MapFrom(src => $"{src.Demographics}"))
            .ForMember(dest => dest.rowguid, opt => opt.MapFrom(src => $"{src.rowguid}"))
            .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => $"{src.ModifiedDate}"))
            .ReverseMap();
            #endregion
        }
    }
}
