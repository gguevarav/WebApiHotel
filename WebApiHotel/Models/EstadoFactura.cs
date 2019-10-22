using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class EstadoFactura
    {
        public EstadoFactura()
        {
            Factura = new HashSet<Factura>();
        }

        public byte IdEstadoFactura { get; set; }
        public string DescripcionEstadoFact { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
