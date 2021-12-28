using Business.Entities;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IPersonPhoneRepository : IRepository<PersonPhone>
    {
        Task<Person> BuscarPessoaPorTelefone(string numeroTelefone);
    }
}
