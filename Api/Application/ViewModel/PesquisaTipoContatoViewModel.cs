using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class PesquisaTipoContatoViewModel
    {
        [Required(ErrorMessage ="Campo obrigatório!")]
        [StringLength(36, ErrorMessage ="Campo IdTipo deve ter no máximo 36 caracteres!")]
        public string IdTipo { get; set; }
    }
}
