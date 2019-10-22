using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class EstadoReservacion
    {
        public EstadoReservacion()
        {
            Reservacion = new HashSet<Reservacion>();
        }

        public byte IdEstadoReservacion { get; set; }
        public string NombreEstadoReservacion { get; set; }

        public virtual ICollection<Reservacion> Reservacion { get; set; }
    }
}
