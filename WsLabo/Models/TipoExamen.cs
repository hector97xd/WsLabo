using System;
namespace WsLabo.Models
{
    public class TipoExamen
    {
        public int Id { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string TipoMuestra { get; set; }
        public double Precio { get; set; }

    }
}

