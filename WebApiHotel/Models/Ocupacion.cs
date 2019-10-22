using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Ocupacion
    {
        public int IdOcupacion { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntradaOcupacion { get; set; }
        public DateTime FechaSalidaOcupacion { get; set; }
        public int IdEstadoReservacion { get; set; }

        public virtual Reservacion IdEstadoReservacionNavigation { get; set; }
        public virtual Habitacion IdHabitacionNavigation { get; set; }
    }
}
