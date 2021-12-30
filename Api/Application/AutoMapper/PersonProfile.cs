using Application.ViewModel;
using AutoMapper;
using Business.Entities;

namespace Application.AutoMapper
{
    public class PersonProfile  : Profile
    {
        public PersonProfile()
        {
            CreateMap<PessoaViewModel, Person>().ReverseMap();
        }
    }
}
