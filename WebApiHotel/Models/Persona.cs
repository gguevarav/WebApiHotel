using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Factura = new HashSet<Factura>();
            Reservacion = new HashSet<Reservacion>();
            TarjetaCliente = new HashSet<TarjetaCliente>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public byte IdSaludo { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string DireccionPersona { get; set; }
        public string NumeroPersona { get; set; }
        public string Nitpersona { get; set; }

        public virtual Saludo IdSaludoNavigation { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Reservacion> Reservacion { get; set; }
        public virtual ICollection<TarjetaCliente> TarjetaCliente { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
