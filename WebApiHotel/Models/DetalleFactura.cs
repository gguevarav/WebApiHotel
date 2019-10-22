using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public byte NumeroLineaDetFact { get; set; }
        public byte CantidadDetalleFactura { get; set; }
        public string DescripcionDetFactura { get; set; }
        public decimal PrecioUnidadDetFactura { get; set; }
        public decimal PrecioTotalDetalleFact { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
    }
}
