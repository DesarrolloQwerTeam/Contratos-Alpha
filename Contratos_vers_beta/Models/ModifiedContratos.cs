using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class ModifiedContratos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }

        public Usuario Usuario { get; set; }

        public Contrato Contrato { get; set; }

        [StringLength(256)]
        public string EmailUser { get; set; }

        [Display(Name = "Acción ejecutada")]
        [StringLength(50)]
        public string ExecutedAction { get; set; }

        [Display(Name = "Hora de ejecución")]
        public DateTime ActionHour { get; set; }


    }
}