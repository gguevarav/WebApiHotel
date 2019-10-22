using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class DetalleReservacion
    {
        public int IdDetalleReservacion { get; set; }
        public int IdReservacion { get; set; }
        public byte NumeroLineaDetalle { get; set; }
        public byte IdHabitacion { get; set; }
        public byte CantidadAdultos { get; set; }
        public byte CantidadNiños { get; set; }

        public virtual Reservacion IdReservacionNavigation { get; set; }
    }
}
