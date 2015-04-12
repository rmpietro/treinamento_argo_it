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

    [RoutePrefix("api/funcionario")]
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE")]
    public class FuncionarioController : ApiController
    {
        FuncionarioRepository repo = new FuncionarioRepository();

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Funcionario> funcs = await repo.GetAll();
            if (funcs == null)
            {
                return NotFound();
            }
            return Ok(funcs);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFuncionarioById(int id)
        {
            Funcionario fun = await repo.GetFuncionarioById(id);
            if (fun == null)
            {
                return NotFound();
            }
            return Ok(fun);
        }

        [Route("email")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFuncionarioByEmail(string email)
        {
            Funcionario func = await repo.GetFuncionarioByEmail(email);
            if (func == null)
            {
                return NotFound();
            }
            return Ok(func);
        }

        public async Task<IHttpActionResult> Post(Funcionario fun)
        {
            int result = await repo.CreateFuncionario(fun);
            if (result == 0)
            {
                return BadRequest();
            }
            return Created(Request.RequestUri + "/funcionario/" + fun.Id, fun);
        }

        public async Task<IHttpActionResult> Put(Funcionario fun)
        {
            int result = await repo.UpdateFuncionario(fun);
            
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            int result = await repo.DeleteFuncionario(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
