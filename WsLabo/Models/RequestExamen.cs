using System;
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
}

