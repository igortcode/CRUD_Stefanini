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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PhoneNumberTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PhoneNumberTypeController>
        [HttpPost("novo")]
        public async Task<TipoContatoViewModel> CriarTipo([FromBody] TipoContatoViewModel type)
        {
            return await _phoneNumberTypeFacade.CadastrarNovoTipo(type);
        }

        // PUT api/<PhoneNumberTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhoneNumberTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
