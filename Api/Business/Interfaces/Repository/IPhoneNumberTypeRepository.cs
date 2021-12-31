using Business.Entities;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface IPhoneNumberTypeRepository : IRepository<PhoneNumberType> {

        Task<PhoneNumberType> BuscarPorNome(string nome);
    }
}
