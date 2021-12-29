using Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IPhoneNumberTypeService
    {
        Task<PhoneNumberType> Novo(PhoneNumberType phoneNumberType);
        Task<PhoneNumberType> Atualizar(PhoneNumberType phoneNumberType);
        Task<List<PhoneNumberType>> Listar(PhoneNumberType phoneNumberType);
        Task Excluir(PhoneNumberType phoneNumberType);
    }
}
