using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Saludo
    {
        public Saludo()
        {
            Persona = new HashSet<Persona>();
        }

        public byte IdSaludo { get; set; }
        public string NombreSaludo { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
