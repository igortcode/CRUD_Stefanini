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
    public class PersonController : ControllerBase
    {
        private readonly IPersonFacade _personFacade;
        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }
        

        [HttpPost("pessoa/buscarporid")]
        public async Task<IActionResult> BuscarPorId([FromBody] BuscarPessoaPorIdViewModel pessoa)
        {
            return Ok(await _personFacade.BuscarPorId(pessoa));
        }

        [HttpPost("pessoa/buscarpornome")]
        public async Task<IActionResult> BuscarPorNome([FromBody] BuscarPessoaPorNomeViewModel pessoa)
        {
            return Ok(await _personFacade.BuscarPorNome(pessoa));
        }

        [HttpGet("pessoa/listar")]
        public async Task<IActionResult> Listar()
        {
            var result = await _personFacade.Listar();
            return Ok(result);
        }

        [HttpPost("pessoa/cadastrar")]
        public async Task<IActionResult> Cadastro([FromBody] CadastroPessoaViewModel cadastro)
        {
            var response = await _personFacade.Novo(cadastro);
            return Ok(response);

        }

        [HttpPost("pessoa/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarPessoaViewModel cadastro)
        {
            var response = await _personFacade.Atualizar(cadastro);
            return Ok(response);

        }

        [HttpPost("pessoa/excluir")]
        public async Task<IActionResult> Excluir([FromBody] BuscarPessoaPorIdViewModel pessoa)
        {
            await _personFacade.Remover(pessoa);
            return Ok();

        }


    }
}
