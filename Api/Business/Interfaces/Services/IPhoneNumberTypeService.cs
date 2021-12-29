using Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IPhoneNumberTypeService
    {
        Task<PhoneNumberType> Novo(PhoneNumberType phoneNumberType);
        Task<PhoneNumberType> BuscarPorId(Guid id);
        Task Atualizar(PhoneNumberType phoneNumberType);
        Task<List<PhoneNumberType>> Listar();
        Task Excluir(PhoneNumberType phoneNumberType);
    }
}
