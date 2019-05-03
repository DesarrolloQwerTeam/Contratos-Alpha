using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class ManageAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }
        public DateTime LoginHour { get; set; }
        public DateTime? LogoutHour { get; set; }

        public bool? LogoutByInactivity { get; set; }
        public Usuario Usuario { get; set; }
    }
}