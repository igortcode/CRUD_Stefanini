using Application.ViewModel;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPhoneNumberTypeFacade
    {
        public Task<TipoContatoViewModel> CadastrarNovoTipo(TipoContatoViewModel tipo);
    }
}
