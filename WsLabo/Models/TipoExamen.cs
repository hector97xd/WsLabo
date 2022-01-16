using System;
namespace WsLabo.Models
{
    public class TipoExamen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoMuestra { get; set; }
        public double Precio { get; set; }
        public double PrecioReferencia { get; set; }

    }
}

