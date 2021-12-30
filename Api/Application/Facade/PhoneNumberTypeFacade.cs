using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Business.Entities;
using Business.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;
        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }

        public async Task<TipoContatoViewModel> CadastrarNovoTipo(TipoContatoViewModel tipo)
        {

            PhoneNumberType type = _mapper.Map<PhoneNumberType>(tipo);

            //PhoneNumberType type = new PhoneNumberType
            //{
            //    Id = new System.Guid(),
            //    Name = tipo.NomeTipo
            //};
            var teste = await _phoneNumberTypeService.Novo(type);
            if(teste != null)
            {
                return new TipoContatoViewModel
                {
                    NomeTipo = teste.Name
                };
            }
            else
            {
                throw new Exception("Não foi possível cadastrar o tipo!");
            }
        }
    }
}
