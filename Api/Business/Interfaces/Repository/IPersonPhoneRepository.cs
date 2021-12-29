using Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IPersonPhoneRepository : IRepository<PersonPhone>
    {
        Task<Person> BuscarPessoaPorTelefone(string numeroTelefone);
        Task AdicionarVarios(ICollection<PersonPhone> personPhones);
        Task AtualizarVarios(Guid idUsuario, ICollection<PersonPhone> personPhones);
        Task ExcluirVarios(Guid idUsuario);
    }
}
