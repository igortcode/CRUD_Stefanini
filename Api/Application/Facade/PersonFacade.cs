using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Business.Entities;
using Business.Exceptions;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly IPhoneNumberTypeService _numberTypeService;
        public PersonFacade(
            IPersonService personService, 
            IMapper mapper, 
            IPhoneNumberTypeService numberTypeService
            )
        {
            _personService = personService;
            _mapper = mapper;
            _numberTypeService = numberTypeService;
        }
        public async Task<PessoaViewModel> Novo(CadastroPessoaViewModel pessoa)
        {
            Person person = _mapper.Map<Person>(pessoa);
            person.Phones = await mapCollectionPersonPhone(person.Id,pessoa.Contato);

            try
            {
                var response = await _personService.Novo(person);
                return mapPersonToPersonViewModel(response);
            }
            catch (Exception ex)
            {

                throw new EntityException("Não foi possível executar este método!" + ex);
            }
            

        }

        private PessoaViewModel mapPersonToPersonViewModel(Person response)
        {
            var pessoa = _mapper.Map<PessoaViewModel>(response);
            pessoa.Contatos = new List<ContatoViewModel>();
            foreach(var contatos in response.Phones)
            {
                pessoa.Contatos.Add(new ContatoViewModel
                {
                    NumeroTelefone = contatos.PhoneNumber,
                    IdTipo = contatos.PhoneNumberTypeId.ToString()

                });
            }
            return pessoa;
        }

        private async Task<ICollection<PersonPhone>> mapCollectionPersonPhone(Guid idPessoa, List<ContatoViewModel> contatos)
        {
            List<PersonPhone> personPhones = new List<PersonPhone>();
            foreach(var contato in contatos)
            {
                Guid idTipo;
                if(Guid.TryParse(contato.IdTipo, out idTipo))
                {
                    try
                    {
                        var type = await _numberTypeService.BuscarPorId(idTipo);
                        if (type != null)
                        {
                            var personPhone = _mapper.Map<PersonPhone>(contato);
                            personPhone.PersonId = idPessoa;
                            personPhone.PhoneNumberTypeId = type.Id;
                            personPhones.Add(personPhone);
                        }
                        else
                        {
                            throw new EntityException("Tipo não encontrado para esse contato: " + contato.NumeroTelefone);
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new EntityException(ex.Message);
                        
                    }                }
                else
                {
                     throw new EntityException("Identificador fornecido não é do tipo Guild: "+contato.IdTipo);
                }
                
            }
            return personPhones;
        }

        public async Task<PessoaViewModel> Atualizar(AtualizarPessoaViewModel pessoa)
        {
            try
            {
                Person person = await mapToPersonAtualizar(pessoa);
                await _personService.Atualizar(person);
                PessoaViewModel response = mapPersonToPersonViewModel(await _personService.ObterComRelacionamentos(person.Id));
                return response;
            }
            catch (Exception ex)
            {

                throw new EntityException("Não foi possível executar este método!" + ex);
            }
        }

        private async Task<Person> mapToPersonAtualizar(AtualizarPessoaViewModel pessoa)
        {
            try
            {
                Guid id;
                if(Guid.TryParse(pessoa.IdPessoa, out id))
                {
                    var pess = await _personService.BuscarPorId(id);
                    if(pess != null)
                    {
                        ICollection<PersonPhone> Phones = await mapCollectionPersonPhone(id, pessoa.Contato);
                        return new Person {Id = id, Name = pessoa.Nome, Phones = Phones };
                    }
                    else
                    {
                        throw new EntityException("Cadastro não encontrado!");
                    }
                }
                else
                {
                    throw new EntityException("Identificador inválido!");
                }
                
            }
            catch (Exception ex)
            {

                throw new EntityException("Não foi possível executar este método!" + ex);
            }
            

        }

        public Task<PessoaViewModel> AtualizarContato(AtualizarContatoPessoaViewModel contato)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PessoaViewModel> BuscarPorId(BuscarPessoaPorIdViewModel idPessoa)
        {
            Guid id;
            try
            {
                if (Guid.TryParse(idPessoa.IdPessoa, out id))
                {
                    var result = await _personService.ObterComRelacionamentos(id);
                    return mapPersonToPersonViewModel(result);
                }
                else
                {
                    throw new EntityException("Identificador inválido!");
                }
            }
            catch(Exception ex)
            {
                throw new EntityException("Não foi possível executar este método!" + ex);
            }
            
        }

        public async Task<List<PessoaViewModel>> BuscarPorNome(BuscarPessoaPorNomeViewModel nome)
        {
            try
            {
                var result = await _personService.ObterComRelacionamentosNome(nome.Nome);
                return mapToListPessoaViewModel(result);
            }
            catch (Exception ex)
            {

                throw new EntityException("Não foi possível executar este método!" + ex);
            }
        }

        public async Task<List<PessoaViewModel>> Listar()
        {
            try
            {
                var pessoas = await _personService.ObterTodosComRelacionamentos();
                List<PessoaViewModel> result = mapToListPessoaViewModel(pessoas);
                return result;
            }
            catch (Exception ex)
            {

                throw new EntityException("Não foi possível executar este método."+ex.Message);
            }
            
           
        }

        private List<PessoaViewModel> mapToListPessoaViewModel(List<Person> pessoas)
        {
            List<PessoaViewModel> pessoaViewModels = new List<PessoaViewModel>();
            foreach(var pessoa in pessoas)
            {
                pessoaViewModels.Add(mapPersonToPersonViewModel(pessoa));
            }
            return pessoaViewModels;
        }

        public async Task Remover(BuscarPessoaPorIdViewModel pessoa)
        {
            try
            {
                Guid id;
                if(Guid.TryParse(pessoa.IdPessoa, out id))
                {
                    var pess = await _personService.ObterComRelacionamentos(id);
                    if(pess != null)
                    {
                        await _personService.Excluir(pess.Id);
                    }
                    else
                    {
                        throw new EntityException("Entidade não encontrada!");
                    }
                }
                else
                {
                    throw new EntityException("Identificador inválido!");
                }
                
            }
            catch(Exception ex)
            {
                throw new EntityException("Não foi possível executar este método." + ex.Message);
            }
        }
    }
}
