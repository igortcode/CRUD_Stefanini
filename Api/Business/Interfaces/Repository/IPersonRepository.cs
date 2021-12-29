using Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> ObterComNumerosDeTelefone(Guid id);
        Task<List<Person>> ObterTodosComNumerosDeTelefone();
    }
}
