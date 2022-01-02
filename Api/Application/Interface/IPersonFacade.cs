using Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPersonFacade
    {
        Task<PessoaViewModel> Novo(CadastroPessoaViewModel pessoa);
        Task<List<PessoaViewModel>> Listar();
        Task<PessoaViewModel> BuscarPorId(BuscarPessoaPorIdViewModel idPessoa);
        Task<List<PessoaViewModel>> BuscarPorNome(BuscarPessoaPorNomeViewModel nome);
        Task<PessoaViewModel> Atualizar(AtualizarPessoaViewModel pessoa);
        Task<PessoaViewModel> AtualizarContato(AtualizarContatoPessoaViewModel contato);
        Task Remover(BuscarPessoaPorIdViewModel pessoa);

    }
}
