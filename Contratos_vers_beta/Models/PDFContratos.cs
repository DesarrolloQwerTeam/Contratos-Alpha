using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class PDFContratos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }
        
        [StringLength(250)]
        [Display(Name = "Nombre del archivo")]
        public string NameFile { get; set; }

        public byte[] File { get; set; }

        //PROPIEDAD SOLO PARA EL RAZOR
        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Seleccionar archivo PDF")]
        public HttpPostedFileBase FileView { get; set; }

        public virtual Contratos Contratos { get; set; }
    }
}