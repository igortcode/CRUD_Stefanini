using Business.Entities;
using Business.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public async Task<Person> ObterComNumerosDeTelefone(Guid id)
        {
            return await _dbSet
                .Include(p => p.Phones)
                .ThenInclude(p => p.PhoneNumberType)
                .FirstOrDefaultAsync( p => p.Id == id);
        }

        public async Task<List<Person>> ObterTodosComNumerosDeTelefone()
        {
            return await _dbSet
                .Include(p => p.Phones)
                .ThenInclude(p => p.PhoneNumberType)
                .ToListAsync();
        }
    }
}
