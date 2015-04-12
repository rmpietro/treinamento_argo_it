using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using FuncBackend.Repositories;

namespace FuncBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE")]
    public class ContatoController : ApiController
    {
        ContatoRepository repo = new ContatoRepository();

        public async Task<IHttpActionResult> Post(Contato contato)
        {
            if (contato == null)
            {
                return BadRequest();
            }
            var result = await repo.CreateContato(contato);
            if (result != 1)
            {
                return InternalServerError();
            }
            return Created(Request.RequestUri + "/contato/" + contato.Id, contato);
        }

        public async Task<IHttpActionResult> Get()
        {
            List<Contato> contatos = await repo.GetAll();
            if (contatos == null)
            {
                return NotFound();
            }
            return Ok(contatos);
        }

    }
}
