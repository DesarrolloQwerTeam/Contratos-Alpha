using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using iText.Kernel.Geom;

namespace Contratos_vers_beta.Models
{
    [NotMapped]
    public class ExportPDF
    {
        public void CreatePdf(string dest, List<Contratos> contratos)
        {
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(dest);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
            Document document = new Document(pdf, PageSize.A4.Rotate());
            
            //Add paragraph to the document
            Table tabla = new Table(16);
            foreach (var item in contratos)
            {
                tabla.AddCell(new Paragraph(item.FECHA.ToString() != "" ? item.FECHA.Value.ToShortDateString() : ""));
                        
                tabla.AddCell(new Paragraph(item.EMPRESA));
                tabla.AddCell(new Paragraph(item.APODERADO));
                tabla.AddCell(new Paragraph(item.FIRMADO ? "Sí" : "No")).SetMaxWidth(10);
                tabla.AddCell(new Paragraph(item.EMPRESA_1));
                tabla.AddCell(new Paragraph(item.APODERADO_1));
                tabla.AddCell(new Paragraph(item.FIRMADO_1? "Sí" : "No")).SetMaxWidth(10);

                //tabla.AddCell(new Paragraph(item.EMPRESA_2));
                //tabla.AddCell(new Paragraph(item.APODERADO_2));
                //tabla.AddCell(new Paragraph(item.FIRMADO_2.ToString()));
                //tabla.AddCell(new Paragraph(item.CONTRAPRESTACION_IVA_INCLUIDO));
                //tabla.AddCell(new Paragraph(item.VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO));
                //tabla.AddCell(new Paragraph(item.ORIGINAL_O_COPIA.ToString()));
                //tabla.AddCell(new Paragraph(item.ANIO_DE_FIRMA));
                //tabla.AddCell(new Paragraph(item.OBSERVACIONES));
            }

            document.Add(tabla);
            //Close document
            document.Close();
        }
    }
}