using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTelefonos.Models
{
    public class Subastas
    {
        public int idSubasta { get; set; }
        public int idDispositivo { get; set; }
        public decimal precioInicial { get; set; }
        public DateTime fin { get; set; }
        public String Dispositivo { get; set; }
    }
}