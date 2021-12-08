using Microsoft.AspNetCore.Mvc;
using QLgs.EdoCta.API.Data;
using QLgs.EdoCta.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLgs.EdoCta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EdoCuentaController : ControllerBase
    {
        private readonly IEdoCtaRepository _repo;
        public EdoCuentaController(IEdoCtaRepository repo)
        {
            this._repo = repo;
            
        }


        // GET <EdoCuentaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = new List<EstadoCta>();

            result = await this._repo.GetExpsCliente(id);

            return Ok(result);
        }

        /*
        // GET: api/<EdoCuentaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // POST api/<EdoCuentaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EdoCuentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EdoCuentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
