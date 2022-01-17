using System;
namespace WsLabo.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual TipoExamen TipoExamen { get; set; }
        public string Estado { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}

