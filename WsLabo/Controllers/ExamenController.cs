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
        [HttpPost("Cotizacion")]
        public async Task<string> GetCotizacion([FromBody] RequestCotizacion request)
        {
            var response = new Response();
            try
            {
                var ls = await _context.TipoExamen.Include(p=> p.Laboratorio).Where(x => x.Laboratorio.Id == request.Id).ToListAsync();
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
        [HttpPost("Seguimiento")]
        public async Task<string> GetSeguimiento([FromBody] RequestSeguimiento request)
        {
            var response = new Response();
            try
            {
                var ls = await _context.Examen.
                    Include(p => p.Paciente).
                    Include(p=> p.TipoExamen).
                    Where(x => x.fechaIngreso <= request.FechaInicio && x.fechaIngreso >= request.FechaFin).ToListAsync();
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
        [HttpPost("Comparacion")]
        public string GetComparacion([FromBody] RequestExamen request)
        {
            var response = new Response();
            try
            {
                var lsExamenes =  _context.TipoExamen.Include(p => p.Laboratorio);
                var ls = new List<TipoExamen>();
                ls.AddRange(lsExamenes);
                var lsLocal =  ls.Where(x=> x.Laboratorio.Id == request.IdLocal && request.Codigos.Any(z => z.Codigo == x.Codigo )).ToList();
                var lsReferencia = ls.Where(x => x.Laboratorio.Id == request.IdReferencia && request.Codigos.Any(z => z.Codigo == x.Codigo)).ToList();
                var lsUnion = lsLocal.Join(lsReferencia,
                    local => local.Codigo,
                    referencia => referencia.Codigo,
                    (local, referencia) => new { Nombre = local.Nombre, Precio = local.Precio, PrecioReferencia = referencia.Precio });
                response.Data = JsonConvert.SerializeObject(lsUnion);
                response.Status = "Ok";
                response.Message = "Lista de Tipo de Examenes";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return JsonConvert.SerializeObject(response);

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

