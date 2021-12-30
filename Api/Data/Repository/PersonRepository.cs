using Business.Entities;
using Business.Interfaces.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly ApiDbContext _context;
        public PersonRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }
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
