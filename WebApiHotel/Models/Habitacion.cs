using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Habitacion
    {
        public Habitacion()
        {
            Ocupacion = new HashSet<Ocupacion>();
        }

        public int IdHabitacion { get; set; }
        public int NumeroHabitacion { get; set; }
        public byte CantidadPersonasHab { get; set; }
        public string UbicacionHabitacion { get; set; }
        public string DescripcionHabitacion { get; set; }
        public byte IdTipoHabitacion { get; set; }
        public decimal PrecioHabitacion { get; set; }
        public byte IdEstadoHabitacion { get; set; }

        public virtual EstadoHabitacion IdEstadoHabitacionNavigation { get; set; }
        public virtual TipoHabitacion IdTipoHabitacionNavigation { get; set; }
        public virtual ICollection<Ocupacion> Ocupacion { get; set; }
    }
}
