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
using iText.Layout.Borders;
using iText.Kernel.Colors;
using iText.IO.Image;

namespace Contratos_vers_beta.Models
{
    [NotMapped]
    public class ExportPDF
    {
        public static MemoryStream CreatePdf(List<Contratos> contratos, MemoryStream ms)
        {
            //Inicializa PDF writer
            PdfWriter writer = new PdfWriter(ms);
            //Inicializa PDF document
            PdfDocument pdf = new PdfDocument(writer);
            //Inicializa document
            Document document = new Document(pdf, PageSize.A4.Rotate());
            //.SetBorder(iText.Layout.Borders.Border.NO_BORDER)
            //Tabla de información
            Table header = new Table(5);
            Cell imagen = new Cell();
            string dirLogo = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            string nombreArchivo = System.IO.Path.Combine(dirLogo, @"Content\img\logo.jpg");
            ImageData data = ImageDataFactory.Create(nombreArchivo);
            Image img = new Image(data);
            imagen.Add(img.SetAutoScale(true)).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
            imagen.SetHeight(45).SetWidth(50);
            
            Cell encabezado = new Cell();
            encabezado.Add(new Paragraph("Listado de contrados").SetBold().SetFontSize(16f)).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetWidth(220).SetHeight(45);

            Cell vacio = new Cell();
            vacio.Add(new Paragraph("")).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetWidth(150).SetHeight(45);
            Cell vacio2 = new Cell();
            vacio2.Add(new Paragraph("")).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetWidth(150).SetHeight(45);

            Cell imagenQT = new Cell();
            string dirQT = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            string nombreQT = System.IO.Path.Combine(dirQT, @"Content\img\QWERTEAMLOGO.png");
            ImageData dataQT = ImageDataFactory.Create(nombreQT);
            Image imgQT = new Image(dataQT);
            imagenQT.Add(imgQT.SetAutoScale(true)).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetBorder(iText.Layout.Borders.Border.NO_BORDER).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
            imagenQT.SetHeight(45).SetWidth(110);

            header.AddCell(imagen);

            header.AddCell(vacio);
            header.AddCell(encabezado);
            header.AddCell(vacio2);
            header.AddCell(imagenQT);

            Table info = new Table(4);
            Cell cell;
            cell = new Cell().Add(new Paragraph("Fecha:")).SetBorder(Border.NO_BORDER);
            info.AddCell(cell);
            cell = new Cell().Add(new Paragraph(DateTime.Today.ToLongDateString())).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(0.5f));
            info.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Número de contratos:")).SetBorder(Border.NO_BORDER);
            info.AddCell(cell);
            cell = new Cell().Add(new Paragraph(contratos.Count.ToString())).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(0.5f));
            info.AddCell(cell);
            info.SetFontSize(5);



            //tabla de contenido
            Table tabla = new Table(16);
            tabla.SetFontSize(4).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            //.SetBackgroundColor(WebColors.GetRGBColor("#FF0000"))

            Cell headerCell = new Cell().Add(new Paragraph("ID").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);

            headerCell = new Cell().Add(new Paragraph("FECHA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("EMPRESA 1").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("APODERADO 1").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("FIRMADO 1").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("EMPRESA 2").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("APODERADO 2").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("FIRMADO 2").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("EMPRESA 3").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("APODERADO 3").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("FIRMADO 3").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("CONTRAPRESTACIÓN").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("VIGENCIA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("ORIGINAL O COPIA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("AÑO DE FIRMA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            headerCell = new Cell().Add(new Paragraph("FINALIZADO").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBold()).SetBackgroundColor(WebColors.GetRGBColor("#7ADEF4"));
            tabla.AddHeaderCell(headerCell);
            
            foreach (var item in contratos)
            {
                //ID
                Cell cellID = new Cell();
                cellID.Add(new Paragraph(item.Id.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)).SetWidth(6).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellID);
                //Fecha
                Cell cellFecha = new Cell();
                cellFecha.Add(new Paragraph(item.FECHA.ToString() != "" ? item.FECHA.Value.ToShortDateString() : "")).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetWidth(10);
                tabla.AddCell(cellFecha);
                //Empresa 1
                Cell cellEMP = new Cell();
                cellEMP.Add(new Paragraph(item.EMPRESA)).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetMaxWidth(75);
                tabla.AddCell(cellEMP);
                //APODERADO 1
                Cell cellAPO1 = new Cell();
                cellAPO1.Add(new Paragraph(item.APODERADO)).SetMaxWidth(63).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellAPO1);
                //Firmado 1
                Cell cellFIR1 = new Cell();
                cellFIR1.Add(new Paragraph(item.FIRMADO ? "Sí" : "No")).SetWidth(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellFIR1);
                //Empresa 2
                Cell cellEMP2 = new Cell();
                cellEMP2.Add(new Paragraph(item.EMPRESA_1)).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetMaxWidth(75);
                tabla.AddCell(cellEMP2);
                //Apoderado 2
                Cell cellAPO2 = new Cell();
                cellAPO2.Add(new Paragraph(item.APODERADO_1)).SetMaxWidth(70).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellAPO2);
                //Firmado 2
                Cell cellFIR2 = new Cell();
                cellFIR2.Add(new Paragraph(item.FIRMADO_1 ? "Sí" : "No")).SetWidth(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellFIR2);
                //Empresa 3
                Cell cellEMP3 = new Cell();
                cellEMP3.Add(new Paragraph((item.EMPRESA_2 != string.Empty) ? item.EMPRESA_2 : "")).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetMaxWidth(75);
                tabla.AddCell(cellEMP3);
                //Apoderado 3
                Cell cellAPO3 = new Cell();
                cellAPO3.Add(new Paragraph((item.APODERADO_2 != string.Empty) ? item.APODERADO_2 : "")).SetMaxWidth(63).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellAPO3);
                //Firmado 3
                Cell cellFIR3 = new Cell();
                cellFIR3.Add(new Paragraph(item.FIRMADO_2 ? "Sí" : "No")).SetWidth(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellFIR3);
                //Contraprestacíón
                Cell cellCONT = new Cell();
                cellCONT.Add(new Paragraph(item.CONTRAPRESTACION_IVA_INCLUIDO)).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetMaxWidth(80);
                tabla.AddCell(cellCONT);
                //Vigencia
                Cell cellVIG = new Cell();
                cellVIG.Add(new Paragraph(item.VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO)).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                tabla.AddCell(cellVIG);
                //Original o copia
                Cell cellOR = new Cell();
                cellOR.Add(new Paragraph(item.ORIGINAL_O_COPIA ? "Copia" : "Original")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetMaxWidth(30);
                tabla.AddCell(cellOR);
                //Año firma
                Cell cellANIO = new Cell();
                cellANIO.Add(new Paragraph(item.ANIO_DE_FIRMA)).SetMaxWidth(30).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                tabla.AddCell(cellANIO);
                //Finalizado
                Cell cellFinalizado = new Cell();
                cellFinalizado.Add(new Paragraph(item.FINALIZADO ? "Finalizado": "Sin finalizar")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE).SetMaxWidth(20);
                tabla.AddCell(cellFinalizado);
                //tabla.AddCell(new Paragraph(item.VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO));
                //tabla.AddCell(new Paragraph(item.ORIGINAL_O_COPIA.ToString()));
                //tabla.AddCell(new Paragraph(item.ANIO_DE_FIRMA));
                //tabla.AddCell(new Paragraph(item.OBSERVACIONES));
            }
            document.Add(header.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER));
            document.Add(info);
            document.Add(new Paragraph(""));
            document.Add(tabla);
            //Close document
            document.Close();

            return ms;
        }
    }
}