using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class Organizacion
    {
        public int Id { get; set; }
        public int Telefono { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Licencia { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime FechaRenovacion { get; set; }
        public double Adeudo { get; set; }
        public bool Servicio { get; set; }
        //public Plan Plan { get; set; }
        public List<Usuario> Usuarios{ get; set; }
        public List<Contrato> Contratos { get; set; }
    }
}