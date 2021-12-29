using Business.Entities;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.ServicesImplementations
{
    public class PersonServices : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonPhoneService _personPhoneService;
        public PersonServices(IPersonRepository personRepository, IPersonPhoneService personPhoneService)
        {
            _personRepository = personRepository;
            _personPhoneService = personPhoneService;
        }
        public async Task<Person> Novo(Person person)
        {
            using(Transaction s)
            await _personPhoneService.Novo(person.Phones.ToList()); 
            return await _personRepository.Adicionar(person);
        }

        public async Task<Person> Atualizar(Person person)
        {
            return await _personRepository.Atualizar(person);
        }

        public async Task<Person> BuscarPorId(Guid id)
        {
            return await _personRepository.ObterPorId(id);
        }

        public async Task Excluir(Guid id)
        {
            await _personRepository.Remover(id);
        }

        public async Task<List<Person>> Listar()
        {
            return await _personRepository.ObterTodos();
        }

       
    }
}
