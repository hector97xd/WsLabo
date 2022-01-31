using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsLabo.Context;
using WsLabo.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WsLabo.Controllers
{
    [Route("api/[controller]")]
    public class LaboController : Controller
    {
        private readonly LaboDbContext _context;
        public LaboController(LaboDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet("ObtenerLaboRef")]
        public string ObtenerListado()
        {
            var response = new Response();
            try
            {
                var ls = _context.Laboratorio.Where(x => x.Id != 1).ToList();
                response.Data = JsonConvert.SerializeObject(ls);
                response.Status = "Ok";
                response.Message = "Lista de Laboratorio";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return JsonConvert.SerializeObject(response);
        }
    }
}

