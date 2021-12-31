using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class AtualizarTipoContatoViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(36, ErrorMessage = "Campo IdTipo deve ter no máximo 36 caracteres!")]
        public string IdTipo { get; set; }

        [Required(ErrorMessage = "Campo tipoNome obrigatório")]
        public string NomeTipo { get; set; }
    }
}
