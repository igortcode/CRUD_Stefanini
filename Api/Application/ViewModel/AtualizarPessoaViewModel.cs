using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class AtualizarPessoaViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(36, ErrorMessage ="Campo deve conter no máximo 36 caracteres!")]
        public string IdPessoa { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, ErrorMessage ="Campo deve conter no máximo 100 e no minimo 3 caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
        public List<ContatoViewModel> Contato { get; set; }
    }
}
