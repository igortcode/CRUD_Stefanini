using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class CadastroTipoContatoViewModel
    {
        [Required(ErrorMessage = "Campo tipoNome obrigatório")]
        public string NomeTipo { get; set; }
    }
}
