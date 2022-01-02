using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class BuscarPessoaPorIdViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(36, ErrorMessage = "Campo deve conter no máximo 36 caracteres!")]
        public string IdPessoa { get; set; }
    }
}
