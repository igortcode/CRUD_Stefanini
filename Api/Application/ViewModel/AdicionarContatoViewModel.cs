using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AdicionarContatoViewModel
    {
        public Guid IdUsuario { get; set; }
        public List<ContatoViewModel> Contatos { get; set; }
    }
}
