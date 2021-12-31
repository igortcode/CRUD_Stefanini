using Business.Entities;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
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
        
        public async Task Atualizar(PhoneNumberType phoneNumberType)
        {
            await _phoneNumberTypeRepository.Atualizar(phoneNumberType);
        }

        public async Task<PhoneNumberType> BuscarPorId(Guid id)
        {
            return await _phoneNumberTypeRepository.ObterPorId(id);
        }

        public async Task<PhoneNumberType> BuscarPorNome(string nome)
        {
            return await _phoneNumberTypeRepository.BuscarPorNome(nome);
        }

        public async Task Excluir(PhoneNumberType phoneNumberType)
        {
            await _phoneNumberTypeRepository.Remover(phoneNumberType.Id);
        }

        public async Task<List<PhoneNumberType>> Listar()
        {
            return await _phoneNumberTypeRepository.ObterTodos();
        }

        public async Task<PhoneNumberType> Novo(PhoneNumberType phoneNumberType)
        {
            return await _phoneNumberTypeRepository.Adicionar(phoneNumberType);
        }
    }
}
