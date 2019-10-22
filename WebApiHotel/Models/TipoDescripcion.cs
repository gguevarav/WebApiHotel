using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class TipoDescripcion
    {
        public TipoDescripcion()
        {
            ListadoTipoDescripcion = new HashSet<ListadoTipoDescripcion>();
        }

        public byte IdTipoDescripcion { get; set; }
        public string NombreTipoDescripcion { get; set; }

        public virtual ICollection<ListadoTipoDescripcion> ListadoTipoDescripcion { get; set; }
    }
}
