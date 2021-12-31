using Business.Entities;
using Business.Interfaces.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PhoneNumberTypeRepository : GenericRepository<PhoneNumberType>, IPhoneNumberTypeRepository
    {
        private readonly ApiDbContext _context;
        public PhoneNumberTypeRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PhoneNumberType> BuscarPorNome(string nome)
        {
            return await _dbSet.AsNoTracking().Where(t => t.Name.Equals(nome)).FirstOrDefaultAsync();
        }
    }
}
