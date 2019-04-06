using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class Bufete
    {
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public Licencia licencia { get; set; }
        [Required]
        public DateTime fechaContratacion { get; set; }
        [Required]
        public DateTime fechaRenovacion { get; set; }
        public float ?adeudo { get; set; }
        public bool servicio { get; set; }
        [Required]
        public string correo { get; set; }
        public int telefono { get; set; }
        
        public enum Licencia
        {
            mensual,
            anual
        }
    }
}