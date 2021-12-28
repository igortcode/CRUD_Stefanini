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
    public class PersonPhoneRepositosy : GenericRepository<PersonPhone>, IPersonPhoneRepository
    {
        public async Task<Person> BuscarPessoaPorTelefone(string numeroTelefone)
        {
            return  _context.PeoplePhones
                .Include(pp => pp.Person)
                .Where(pp => pp.PhoneNumber
                .Equals(numeroTelefone))
                .Select(p => p.Person).FirstOrDefault();
        }
    }
}
