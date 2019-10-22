using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Reservacion
    {
        public Reservacion()
        {
            DetalleReservacion = new HashSet<DetalleReservacion>();
            Ocupacion = new HashSet<Ocupacion>();
        }

        public int IdReservacion { get; set; }
        public int IdPersona { get; set; }
        public DateTime DiaIngresoReservacion { get; set; }
        public DateTime DiaSalidaReservacion { get; set; }
        public byte IdEstadoReservacion { get; set; }

        public virtual EstadoReservacion IdEstadoReservacionNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<DetalleReservacion> DetalleReservacion { get; set; }
        public virtual ICollection<Ocupacion> Ocupacion { get; set; }
    }
}
