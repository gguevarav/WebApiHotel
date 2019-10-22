using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class ListadoTipoDescripcion
    {
        public int IdListadoTipoDescrip { get; set; }
        public byte IdTipoHabitacion { get; set; }
        public byte IdTipoDescripcion { get; set; }

        public virtual TipoDescripcion IdTipoDescripcionNavigation { get; set; }
        public virtual TipoHabitacion IdTipoHabitacionNavigation { get; set; }
    }
}
