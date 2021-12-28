using Business.Entities;
using Business.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public async Task<Person> ObterComNumerosDeTelefone(Guid id)
        {
            return await _context.People
                .Include(p => p.Phones)
                .ThenInclude(p => p.PhoneNumberType)
                .FirstOrDefaultAsync();
        }
    }
}
