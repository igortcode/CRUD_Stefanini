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
                .ForMember(tc => tc.Id, op => op.MapFrom(src => src.IdTipo))
                .ReverseMap();

            CreateMap<CadastroTipoContatoViewModel, PhoneNumberType>()
                .ForMember(tc => tc.Name, op => op.MapFrom(src => src.NomeTipo))
                .ReverseMap();

            CreateMap<AtualizarTipoContatoViewModel, PhoneNumberType>()
               .ForMember(tc => tc.Name, op => op.MapFrom(src => src.NomeTipo))
               .ForMember(tc => tc.Id, op => op.MapFrom(src => src.IdTipo))
               .ReverseMap();
        }
    }
}
