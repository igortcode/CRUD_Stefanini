using Business.Entities;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServicesImplementations
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;

        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }
        
        public Task<PhoneNumberType> Atualizar(PhoneNumberType phoneNumberType)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(PhoneNumberType phoneNumberType)
        {
            throw new NotImplementedException();
        }

        public Task<List<PhoneNumberType>> Listar(PhoneNumberType phoneNumberType)
        {
            throw new NotImplementedException();
        }

        public async Task<PhoneNumberType> Novo(PhoneNumberType phoneNumberType)
        {
            return await _phoneNumberTypeRepository.Adicionar(phoneNumberType);
        }
    }
}
