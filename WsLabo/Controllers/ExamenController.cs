using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WsLabo.Context;
using WsLabo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WsLabo.Controllers
{
    
    [Route("api/[controller]")]
    public class ExamenController : Controller
    {
        private readonly LaboDbContext _context;
        public ExamenController(LaboDbContext context)
        {
            _context = context;
        }
        [HttpGet("Cotizacion")]
        public async Task<string> Get()
        {
            var response = new Response();
            try
            {
                var ls = await _context.TipoExamen.ToListAsync();
                response.Data = JsonConvert.SerializeObject(ls);
                response.Status = "Ok";
                response.Message = "Lista de Tipo de Examenes";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return JsonConvert.SerializeObject(response);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

