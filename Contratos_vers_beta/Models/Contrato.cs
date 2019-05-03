﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contratos_vers_beta.Models
{
    public class Contrato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }

        public Organizacion Organizacion { get; set; }

        [Display(Name = "Clave del Contrato")]
        [StringLength(250)]
        public string CLAVE_DEL_CONTRATO { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? FECHA { get; set; }

        [Display(Name = "Empresa 1")]
        [StringLength(250)]
        public string EMPRESA { get; set; }

        [Display(Name = "Apoderado 1")]
        [StringLength(500)]
        public string APODERADO { get; set; }

        [Display(Name = "Firma Apoderado 1")]
        public Boolean FIRMADO { get; set; }

        [Display(Name = "Empresa 2")]
        [StringLength(250)]
        public string EMPRESA_1 { get; set; }

        [Display(Name = "Apoderado 2")]
        [StringLength(500)]
        public string APODERADO_1 { get; set; }

        [Display(Name = "Firma Apoderado 2")]
        public Boolean FIRMADO_1 { get; set; }

        [Display(Name = "Empresa 3")]
        [StringLength(250)]
        public string EMPRESA_2 { get; set; }

        [Display(Name = "Apoderado 3")]
        [StringLength(500)]
        public string APODERADO_2 { get; set; }

        [Display(Name = "Firma Apoderado 3 ")]
        public Boolean FIRMADO_2 { get; set; }

        [Display(Name = "Contraprestación IVA incluido")]
        [StringLength(250)]
        public string CONTRAPRESTACION_IVA_INCLUIDO { get; set; }

        [Display(Name = "Vigencia Del Convenio")]
        [StringLength(250)]
        public string VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO { get; set; }

        [Display(Name = "Original o copia")]
        public Boolean ORIGINAL_O_COPIA { get; set; }

        [Display(Name = "Año de la firma ")]
        [StringLength(20)]
        public string ANIO_DE_FIRMA { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(250)]
        public string OBSERVACIONES { get; set; }

        public PDFContratos PDFContrato { get; set; }
        public List<ModifiedContratos> ModificacionContrato { get; set; }
    }
}