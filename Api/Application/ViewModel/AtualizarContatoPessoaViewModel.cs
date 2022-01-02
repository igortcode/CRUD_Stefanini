using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AtualizarContatoPessoaViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(36, ErrorMessage = "Campo deve conter no máximo 36 caracteres!")]
        public string IdPessoa { get; set; }
        public List<ContatoViewModel> Contato { get; set; }
    }
}
