using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsLabo.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }
        public string Dui { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaIngreso { get; set; }
    }
}

