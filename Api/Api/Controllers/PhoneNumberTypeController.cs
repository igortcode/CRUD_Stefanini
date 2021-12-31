using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PhoneNumberTypeController : ControllerBase
    {
        private readonly IPhoneNumberTypeFacade _phoneNumberTypeFacade;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade phoneNumberTypeFacade)
        {
            _phoneNumberTypeFacade = phoneNumberTypeFacade;      
        }
        
        // GET: api/<PhoneNumberTypeController>
        [HttpGet("tipo/listar")]
        public async Task<IActionResult> ListarTipos()
        {
            return Ok(await _phoneNumberTypeFacade.ListarTipos());
        }

        // GET api/<PhoneNumberTypeController>/5
        [HttpPost("tipo/buscar")]
        public async Task<IActionResult> BuscarTipo([FromBody] PesquisaTipoContatoViewModel type)
        {
           var result = await _phoneNumberTypeFacade.BuscarPorIdTipos(type);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Registro não encontrado");
        }

        [HttpPost("tipo/buscar/nome")]
        public async Task<IActionResult> BuscarTipoNome([FromBody] TipoContatoViewModel type)
        {
            var result = await _phoneNumberTypeFacade.BuscarPorNome(type);
            if (result != null)
                return Ok(result);
            else
                return NotFound("Registro não encontrado");
        }

        // POST api/<PhoneNumberTypeController>
        [HttpPost("tipo/novo")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroTipoContatoViewModel type)
        {
            var result = await _phoneNumberTypeFacade.CadastrarNovoTipo(type);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Não foi possivel cadastrar!");
        }

        [HttpPost("tipo/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarTipoContatoViewModel type)
        {
            var result = await _phoneNumberTypeFacade.AtualizarTipo(type);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Não foi possivel atualizar!");
        }

        // DELETE api/<PhoneNumberTypeController>/5
        [HttpPost("tipo/excluir")]
        public async Task<IActionResult> Excluir([FromBody] PesquisaTipoContatoViewModel type)
        {
            if(await _phoneNumberTypeFacade.RemoverTipo(type))
            {
                return Ok("Cadastro excluido com sucesso!");
            }
            else
            {
               return NotFound("Não foi possível excluir!");
            }
        }
    }
}
