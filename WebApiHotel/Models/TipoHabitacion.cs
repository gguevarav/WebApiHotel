using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class TipoHabitacion
    {
        public TipoHabitacion()
        {
            Habitacion = new HashSet<Habitacion>();
            ListadoTipoDescripcion = new HashSet<ListadoTipoDescripcion>();
        }

        public byte IdTipoHabitacion { get; set; }
        public string NombreTipoHabitacion { get; set; }

        public virtual ICollection<Habitacion> Habitacion { get; set; }
        public virtual ICollection<ListadoTipoDescripcion> ListadoTipoDescripcion { get; set; }
    }
}
