using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class EstadoHabitacion
    {
        public EstadoHabitacion()
        {
            Habitacion = new HashSet<Habitacion>();
        }

        public byte IdEstadoHabitacion { get; set; }
        public string DescripcionEstadoHab { get; set; }

        public virtual ICollection<Habitacion> Habitacion { get; set; }
    }
}
