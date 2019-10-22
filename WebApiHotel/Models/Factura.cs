using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int IdFactura { get; set; }
        public int NumeroFactura { get; set; }
        public string SerieFactura { get; set; }
        public int IdPersona { get; set; }
        public string TipoPagoFactura { get; set; }
        public decimal MontoFactura { get; set; }
        public byte IdEstadoFactura { get; set; }

        public virtual EstadoFactura IdEstadoFacturaNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
