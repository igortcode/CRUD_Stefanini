using Application.ViewModel;
using Business.Entities;
using Business.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Application.Facade
{
    public class PhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
        }

        public async Task<TipoContatoViewModel> CadastrarNovoTipo(TipoContatoViewModel tipo)
        {
            PhoneNumberType type = new PhoneNumberType
            {
                Id = new System.Guid(),
                Name = tipo.NomeTipo
            };
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
