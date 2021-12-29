using Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IPersonPhoneService
    {
        Task<PersonPhone> Novo(List<PersonPhone> personPhones);
        Task<PersonPhone> Atualizar(PersonPhone personPhone);
        Task<List<PersonPhone>> Listar(PersonPhone personPhone);
    }
}
