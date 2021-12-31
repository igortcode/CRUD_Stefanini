using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPhoneNumberTypeFacade
    {
        public Task<CadastroTipoContatoViewModel> CadastrarNovoTipo(CadastroTipoContatoViewModel tipo);
        public Task<TipoContatoViewModel> AtualizarTipo(AtualizarTipoContatoViewModel tipo);
        public Task<List<TipoContatoViewModel>> ListarTipos();
        public Task<TipoContatoViewModel> BuscarPorIdTipos(PesquisaTipoContatoViewModel IdTipo);
        public Task<TipoContatoViewModel> BuscarPorNome(TipoContatoViewModel tipo);
        public Task<bool> RemoverTipo(PesquisaTipoContatoViewModel tipo);
    }
}
