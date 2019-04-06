using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class Serial
    {
        public int id { get; set; }
        public int idOrganizacion { get; set; }

        [Required]
        public string serial { get; set; }
    }
}