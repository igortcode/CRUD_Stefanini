using Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IPersonService
    {
        Task<Person> Novo(Person person);
        Task<Person> Atualizar(Person person);
        Task<Person> BuscarPorId(Guid id);
        Task<Person> ObterComRelacionamentos(Guid id);
        Task<List<Person>> ObterTodosComRelacionamentos();
        Task<List<Person>> Listar();
        Task Excluir(Guid id);
    }
}
