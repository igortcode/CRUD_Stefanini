using Business.Entities;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> ObterComNumerosDeTelefone(Guid id);
    }
}
