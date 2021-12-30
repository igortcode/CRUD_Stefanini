using Application.ViewModel;
using AutoMapper;
using Business.Entities;

namespace Application.AutoMapper
{
    public class PhoneNumberTypeProfile : Profile
    {
        public PhoneNumberTypeProfile()
        {
            CreateMap<TipoContatoViewModel, PhoneNumberType>()
                .ForMember(tc => tc.Name, op => op.MapFrom(src => src.NomeTipo))
                .ReverseMap();
        }
    }
}
