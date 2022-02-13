using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsLabo.Models
{
    public class RequestExamen
    {
        public int IdLocal { get; set; }
        public int IdReferencia { get; set; }
        public List<Codigos> Codigos { get; set; }
    }
    public class Codigos
    {
        public string Codigo { get; set; }
    }
    public class RequestCotizacion
    {
        public int Id { get; set; }
    }
    public class RequestSeguimiento
    {
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaFin { get; set; }
    }
    public class RequestExam
    {
        public int Id { get; set; }
        public int Paciente { get; set; }
        public List<int> TipoExamen { get; set; }
        public string Estado { get; set; }
        public string UsuarioIngreso { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime fechaIngreso { get; set; }
    }
}

