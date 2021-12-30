using Application.ViewModel;
using AutoMapper;
using Business.Entities;

namespace Application.AutoMapper
{
    public class PersonPhoneProfile : Profile
    {
        public PersonPhoneProfile()
        {
            CreateMap<ContatoViewModel, PersonPhone>()
                .ReverseMap();
        }
    }
}
