using System;
namespace WsLabo.Models
{
    public class TipoExamen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double PrecioReferencia { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public double TotalReferencia { get; set; }
    }
}

