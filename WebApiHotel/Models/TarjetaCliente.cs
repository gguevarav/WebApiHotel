using System;
using System.Collections.Generic;

namespace WebApiHotel.Models
{
    public partial class TarjetaCliente
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string NombreTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public byte MesVencimiento { get; set; }
        public byte AnioVencimiento { get; set; }
        public byte Ccv { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
