using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    
    public class BuscarPessoaPorNomeViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, ErrorMessage = "Campo deve conter no máximo 100 e no minimo 3 caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
    }
}
