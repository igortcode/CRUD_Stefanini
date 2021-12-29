using Business.Entities;
using Business.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PersonPhoneRepository : GenericRepository<PersonPhone>, IPersonPhoneRepository
    {
        public async Task AdicionarVarios(ICollection<PersonPhone> personPhones)
        {
            await _dbSet.AddRangeAsync(personPhones);
            await SaveChanges();
        }

        public async Task AtualizarVarios(Guid idUsuario, ICollection<PersonPhone> personPhones)
        {
            var result = await _dbSet.Where(pp => pp.PersonId == idUsuario).ToListAsync();
            _dbSet.RemoveRange(result);
            await _dbSet.AddRangeAsync(personPhones);
            await SaveChanges();
        }

        public async Task<Person> BuscarPessoaPorTelefone(string numeroTelefone)
        {
            return  _context.PeoplePhones
                .Include(pp => pp.Person)
                .Where(pp => pp.PhoneNumber
                .Equals(numeroTelefone))
                .Select(p => p.Person).FirstOrDefault();
        }

        public async Task ExcluirVarios(Guid idUsuario)
        {
            var result = await _dbSet.Where(pp => pp.PersonId == idUsuario).ToListAsync();
            _dbSet.RemoveRange(result);
            await SaveChanges();
        }
    }
}
