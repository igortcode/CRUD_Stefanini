using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Business.Entities;
using Business.Exceptions;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IMapper _mapper;
        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper, IPersonPhoneRepository personPhoneRepository)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _personPhoneRepository = personPhoneRepository;
            _mapper = mapper;
        }

        public async Task<CadastroTipoContatoViewModel> CadastrarNovoTipo(CadastroTipoContatoViewModel tipo)
        {
            PhoneNumberType type = _mapper.Map<PhoneNumberType>(tipo);
            PhoneNumberType tipoContatoCadastrado;
            try
            {
                if (await validarRegistro(tipo.NomeTipo))
                {
                    tipoContatoCadastrado = await _phoneNumberTypeService.Novo(type);
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                //Criar log
                throw new EntityException("Não foi possível executar este método! " + ex);
            }

            if (tipoContatoCadastrado != null)
            {
                return _mapper.Map<CadastroTipoContatoViewModel>(tipoContatoCadastrado);
            }
            else
            {
                throw new Exception("Não foi possível cadastrar o tipo!");
            }
        }

        public async Task<TipoContatoViewModel> AtualizarTipo(AtualizarTipoContatoViewModel tipo)
        {
            try
            {
                Guid id;
                if (Guid.TryParse(tipo.IdTipo, out id))
                {

                    PhoneNumberType tipoContrato = await _phoneNumberTypeService.BuscarPorId(id);
                    if (await validarRegistro(tipo.NomeTipo))
                    {
                        if (tipoContrato != null)
                        {
                            PhoneNumberType type = _mapper.Map<PhoneNumberType>(tipo);
                            type.Id = id;
                            await _phoneNumberTypeService.Atualizar(type);
                            var tipoContratoAtualizado = await _phoneNumberTypeService.BuscarPorId(id);

                            return _mapper.Map<TipoContatoViewModel>(tipoContratoAtualizado);
                        }
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //criar log
                //criar exceptions
                throw new EntityException("Não foi possível executar este método! " + ex);
            }
        }

        private async Task<bool> validarRegistro(string nomeTipo)
        {
            try
            {
                var type = await _phoneNumberTypeService.BuscarPorNome(nomeTipo);
                if(type == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new EntityException("Não foi possível executar este método! " + ex);
            }
        }

        public async Task<TipoContatoViewModel> BuscarPorIdTipos(PesquisaTipoContatoViewModel idTipo)
        {
            Guid id;
            if (Guid.TryParse(idTipo.IdTipo, out id))
            {
                try
                {
                    var type = await _phoneNumberTypeService.BuscarPorId(id);
                    if (type != null)
                    {
                        return _mapper.Map<TipoContatoViewModel>(type);
                    }
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    //criar log
                    //criar exceptions
                    throw new EntityException("Não foi possível executar este método! " + ex);
                }

            }
            else
                return null;
        }

        public async Task<TipoContatoViewModel> BuscarPorNome(TipoContatoViewModel tipo)
        {
            try
            {
                var type = await _phoneNumberTypeService.BuscarPorNome(tipo.NomeTipo);
                if (type != null)
                {
                    return _mapper.Map<TipoContatoViewModel>(type);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                //criar log
                //criar exceptions
                throw new EntityException("Não foi possível executar este método! " + ex);
            }
        }



        public async Task<List<TipoContatoViewModel>> ListarTipos()
        {
            try
            {
                var result = await _phoneNumberTypeService.Listar();
                return parseToTipoContatoViewModel(result);
            }
            catch (Exception ex)
            {
                //criar log
                //criar exceptions
                throw new EntityException("Não foi possível executar este método! " + ex);
            }
        }

        public async Task<bool> RemoverTipo(PesquisaTipoContatoViewModel idTipo)
        {
            Guid id;
            if (Guid.TryParse(idTipo.IdTipo, out id))
            {
                try
                {
                    var type = await _phoneNumberTypeService.BuscarPorId(id);
                    var personPhones = (await _personPhoneRepository.ObterTodos()).Where(pp => pp.PhoneNumberTypeId == type.Id).ToList(); 

                    if (type != null)
                    {
                        if(personPhones.Count > 0) {
                            throw new EntityException("Não foi possível excluir, existe contatos de pessoas que utilizam este tipo!");
                        }
                        else
                        {
                            await _phoneNumberTypeService.Excluir(type);
                            return true;
                        }
                        
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    //criar log
                    //criar exceptions
                    throw new EntityException("Não foi possível executar este método! " + ex);
                }

            }
            else
                return false;
        }

        private List<TipoContatoViewModel> parseToTipoContatoViewModel(List<PhoneNumberType> listaTipos)
        {
            List<TipoContatoViewModel> listaViewModel = new List<TipoContatoViewModel>();
            foreach (var tipo in listaTipos)
            {
                listaViewModel.Add(_mapper.Map<TipoContatoViewModel>(tipo));
            }
            return listaViewModel;
        }
    }
}
