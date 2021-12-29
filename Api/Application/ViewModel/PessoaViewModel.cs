using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class PessoaViewModel
    {
        public Guid IdPessoa { get; set; }
        public string Nome { get; set; }    
        public List<ContatoViewModel> Contato { get; set; }
    }
}
