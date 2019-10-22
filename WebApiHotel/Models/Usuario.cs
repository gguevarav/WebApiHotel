using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string CorreoUsuario { get; set; }
        public string ContraseniaUsuario { get; set; }
        public byte IdRol { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
