using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsLabo.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual TipoExamen TipoExamen { get; set; }
        public string Estado { get; set; }
        public string UsuarioIngreso { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime fechaIngreso { get; set; }      
    }
}

