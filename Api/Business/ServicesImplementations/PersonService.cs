using Business.Entities;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.ServicesImplementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonService(IPersonRepository personRepository, IPersonPhoneRepository personPhoneRepository)
        {
            _personRepository = personRepository;
            _personPhoneRepository = personPhoneRepository;
        }
        public async Task<Person> Novo(Person person)
        {
            await _personRepository.Adicionar(person);
            await _personPhoneRepository.AdicionarVarios(person.Phones);
            return  await _personRepository.ObterComNumerosDeTelefone(person.Id); 
        }

        public async Task<Person> Atualizar(Person person)
        {
            await _personRepository.Atualizar(person);
            await _personPhoneRepository.AtualizarVarios(person.Id, person.Phones);
            return await _personRepository.ObterComNumerosDeTelefone(person.Id);
        }

        public async Task<Person> BuscarPorId(Guid id)
        {
            return await _personRepository.ObterPorId(id);
        }

        public async Task<Person> ObterComRelacionamentos(Guid id)
        {
            return await _personRepository.ObterComNumerosDeTelefone(id);
        }

        public async Task Excluir(Guid id)
        {
            await _personPhoneRepository.ExcluirVarios(id);
            await _personRepository.Remover(id);
        }

        public async Task<List<Person>> Listar()
        {
            return await _personRepository.ObterTodos();
        }

        public async Task<List<Person>> ObterTodosComRelacionamentos()
        {
            return await _personRepository.ObterTodosComNumerosDeTelefone();
        }
    }
}
