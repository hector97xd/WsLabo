using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WsLabo.Context;
using Newtonsoft.Json;
using WsLabo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WsLabo.Controllers
{    
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly LaboDbContext _context;
        public PacienteController(LaboDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet("Listado")]
        public async Task<string> Get()
        {
            var response = new Response();
            try
            {
                var ls = await _context.Paciente.ToListAsync();
                response.Data = JsonConvert.SerializeObject(ls);
                response.Status = "Ok";
                response.Message = "Lista de Pacientes";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return JsonConvert.SerializeObject(response);

        }


        // POST api/values
        [HttpPost("Agregar")]
        public async Task<string> Post([FromBody] Paciente paciente)
        {
            var response = new Response();
            try
            {
                _context.Paciente.Add(paciente);
                await _context.SaveChangesAsync();
                response.Status = "Ok";
                response.Message = "Datos insertados correctamente.";
                response.Data = JsonConvert.SerializeObject(paciente);

            }
            catch (Exception ex)
            {              
                response.Status = "Error";
                response.Message = ex.ToString();
                response.Data = "";
            }
            return JsonConvert.SerializeObject(response);

        }

        // PUT api/values/5
        [HttpPut("Modificar/{id}")]
        public async Task<string> Put(int? id,[FromBody] Paciente datos)
        {
            var response = new Response();
            try
            {
                if(id == null)
                {
                    response.Status = "Warning";
                    response.Message = "Se debe enviar el id";
                    response.Data = JsonConvert.SerializeObject(datos);
                }
                var paciente = _context.Paciente.FirstOrDefault(x=>x.Id == id);
                if(paciente != null)
                {
                    paciente.Nombre = datos.Nombre;
                    paciente.Apellido = datos.Apellido;
                    paciente.Direccion = datos.Direccion;
                    paciente.Telefono = datos.Telefono;
                    paciente.FechaNacimiento = datos.FechaNacimiento;
                    paciente.Dui = datos.Dui;
                    paciente.Correo = datos.Correo;
                    await _context.SaveChangesAsync();
                    response.Status = "Ok";
                    response.Message = "Datos modificado correctamente.";
                    response.Data = JsonConvert.SerializeObject(datos);
                }
                else
                {
                    response.Status = "Warning";
                    response.Message = "Dato no encontrado";
                    response.Data = JsonConvert.SerializeObject(datos);
                }
                

            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = ex.ToString();
                response.Data = "";
            }
            return JsonConvert.SerializeObject(response);
        }

        // DELETE api/values/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<string> Delete(int? id)
        {
            var response = new Response();
            try
            {
                if (id == null)
                {
                    response.Status = "Warning";
                    response.Message = "Se debe enviar el id";
                    response.Data = "";
                }
                var paciente = _context.Paciente.Find(id);

                if (paciente != null)
                {
                    _context.Paciente.Remove(paciente);
                    await _context.SaveChangesAsync();
                    response.Status = "Ok";
                    response.Message = "Registro eliminado correctamente.";
                    response.Data = JsonConvert.SerializeObject(paciente);
                }
                else
                {
                    response.Status = "Warning";
                    response.Message = "Dato no encontrado";
                    response.Data = JsonConvert.SerializeObject(paciente);
                }


            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = ex.ToString();
                response.Data = "";
            }
            return JsonConvert.SerializeObject(response);
        }
    }
}

