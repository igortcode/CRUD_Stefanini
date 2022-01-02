using Application.ViewModel;
using AutoMapper;
using Business.Entities;

namespace Application.AutoMapper
{
    public class PersonProfile  : Profile
    {
        public PersonProfile()
        {
            CreateMap<CadastroPessoaViewModel, Person>()
                .ForMember(p => p.Name, op => op.MapFrom(p => p.Nome))
                .ReverseMap();
            CreateMap<ContatoViewModel, PersonPhone>()
                .ForMember(p => p.PhoneNumber, op => op.MapFrom(p => p.NumeroTelefone))
                .ReverseMap();
            CreateMap<AtualizarPessoaViewModel, Person>()
                .ForMember(p => p.Name, op => op.MapFrom(p => p.Nome))
                .ReverseMap();

            CreateMap<PessoaViewModel, Person>()
                .ForMember(p => p.Id, op => op.MapFrom(p => p.IdPessoa))
                .ForMember(p => p.Name, op => op.MapFrom(p => p.Nome))
                .ReverseMap();
        }
    }
}
