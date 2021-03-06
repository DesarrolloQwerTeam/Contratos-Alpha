﻿using Contratos_vers_beta.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Contratos_vers_beta.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    using (ApplicationDbContext _db = new ApplicationDbContext())
            //    {
            //        var _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));

            //        var resultado = _roleManager.Create(new IdentityRole("desarrollo"));
            //    }
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ViewContratos()
        {
            ViewBag.Success = null;
            ViewBag.Error = null;

            try
            {
                using (AppDbContext app = new AppDbContext())
                {
                    var model = app.Contratos.ToList();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Contratos_Read([DataSourceRequest]DataSourceRequest request)
        {
            return await Task.Run(() =>
                {
                    IQueryable<Contratos> contratos = db.Contratos;

                    DataSourceResult result = contratos.ToDataSourceResult(request, customer => new
                    {
                        customer.CLAVE_DEL_CONTRATO,
                        customer.FECHA,
                        customer.Contrato_Convenio,
                        customer.Tipo_Contrato_Convenio,
                        customer.EMPRESA,
                        customer.APODERADO,
                        customer.FIRMADO,
                        customer.EMPRESA_1,
                        customer.APODERADO_1,
                        customer.FIRMADO_1,
                        customer.EMPRESA_2,
                        customer.APODERADO_2,
                        customer.FIRMADO_2,
                        customer.CONTRAPRESTACION_IVA_INCLUIDO,
                        customer.VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO,
                        customer.ORIGINAL_O_COPIA,
                        customer.ANIO_DE_FIRMA,
                        customer.OBSERVACIONES,
                        customer.Id,
                        customer.FINALIZADO
                    });

                    return Json(result);
                });
        }


        [HttpGet]
        public ActionResult ImportExcelContratos()
        {
            ViewBag.Success = null;
            ViewBag.Error = null;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ImportExcelContratos(HttpPostedFileBase excelfile)
        {
            try
            {
                if (excelfile == null || excelfile.ContentLength == 0)
                {
                    ViewBag.Error = "Archivo dañado.";
                    return View("ImportExcelContratos");
                }
                else
                {
                    if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                    {
                        var model = await ExcelAsync(excelfile);

                        return View(model);
                    }
                    else
                    {
                        ViewBag.Error = "Por favor seleccionar un archivo excel";
                        return View("ImportExcelContratos");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("ImportExcelContratos");
            }
        }

        private async Task<IEnumerable<Contratos>> ExcelAsync(HttpPostedFileBase excelfile)
        {
            return await Task.Run(() =>
            {
                string Filename = Guid.NewGuid() + Path.GetExtension(excelfile.FileName);

                excelfile.SaveAs(Path.Combine(Server.MapPath("~/excelfolder"), Filename));

                string Fullpath = Server.MapPath("/excelfolder/") + Filename;

                var package = new ExcelPackage(new FileInfo(Fullpath));

                ExcelWorksheet workSheet = package.Workbook.Worksheets["BD Con"];

                IEnumerable<Contratos> model;
                List<Contratos> ListConvenio = new List<Contratos>();

                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    Contratos c = new Contratos
                    {
                        CLAVE_DEL_CONTRATO = workSheet.Cells[i, 4].Text,
                        FECHA = DBNull.Value.Equals(workSheet.Cells[i, 5].Value.ToString()) == true ? (DateTime?)null : DateTime.Parse(workSheet.Cells[i, 5].Value.ToString()),
                        Contrato_Convenio = (workSheet.Cells[i, 6].Value.ToString() == "CONTRATO") ? true : false,
                        Tipo_Contrato_Convenio = workSheet.Cells[i, 7].Text,
                        EMPRESA = workSheet.Cells[i, 8].Text,
                        APODERADO = workSheet.Cells[i, 9].Text,
                        FIRMADO = workSheet.Cells[i, 10].Text == "SI" ? true : false,
                        EMPRESA_1 = workSheet.Cells[i, 11].Text,
                        APODERADO_1 = workSheet.Cells[i, 12].Text,
                        FIRMADO_1 = workSheet.Cells[i, 13].Text == "SI" ? true : false,
                        EMPRESA_2 = workSheet.Cells[i, 14].Text,
                        APODERADO_2 = workSheet.Cells[i, 15].Text,
                        FIRMADO_2 = workSheet.Cells[i, 16].Text == "SI" ? true : false,
                        CONTRAPRESTACION_IVA_INCLUIDO = workSheet.Cells[i, 17].Text,
                        VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO = workSheet.Cells[i, 18].Text,
                        ORIGINAL_O_COPIA = workSheet.Cells[i, 19].Text == "ORIGINAL" ? true : false,
                        ANIO_DE_FIRMA = workSheet.Cells[i, 22].Text,
                        OBSERVACIONES = workSheet.Cells[i, 21].Text,
                        //FINALIZADO = false,
                    };
                    ListConvenio.Add(c);
                }

                model = ListConvenio.AsEnumerable();

                return model;
            });

        }

        [HttpGet]
        public ActionResult AddContratos()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddContratos(IEnumerable<Contratos> model)
        {
            try
            {
                db.Contratos.AddRange(model);
                await db.SaveChangesAsync();

                await Task.Run(() =>
                {
                    using (AppDbContext app = new AppDbContext())
                    {
                        List<ModifiedContratos> modifieds = new List<ModifiedContratos>();
                        foreach (var item in model)
                        {
                            var RegisterContratos = new ModifiedContratos
                            {
                                ExecutedAction = $"Exportó de un Excel, el contrato RHDEMO00{item.Id}",
                                ActionHour = DateTime.Now,
                                EmailUser = User.Identity.GetUserName(),
                                IdUser = User.Identity.GetUserId(),
                                ClaveContrato = item.CLAVE_DEL_CONTRATO,
                            };
                            modifieds.Add(RegisterContratos);
                        }

                        app.ModifiedContratos.AddRange(modifieds);
                        app.SaveChanges();
                    }
                });
                ViewBag.Success = "Se guardaron todas las filas correctamente.";
                return RedirectToAction("ViewContratos");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View("ViewContratos");
            }
        }

        [HttpGet]
        public ActionResult ImportPDFContratos(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Contratos Contratos = db.Contratos.Find(Id);

            if (Contratos == null)
                return HttpNotFound();

            PDFContratos model = new PDFContratos
            {
                Contratos = Contratos,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ImportPDFContratos(PDFContratos model)
        {
            if (model.FileView == null || model.FileView.ContentLength == 0)
            {
                ViewBag.Error = "Archivo dañado.";
                return View();
            }
            else
            {
                if (model.FileView.FileName.EndsWith("pdf"))
                {
                    using (AppDbContext app = new AppDbContext())
                    {
                        var FindContratos = app.Contratos.Find(model.Contratos.Id);

                        if (FindContratos == null)
                            return HttpNotFound();

                        var FindPDFContratos = app.PDFContratos.Where(x => x.Contratos.Id == FindContratos.Id).AsEnumerable();
                        if (FindPDFContratos.Count() > 0)
                        {
                            var pDFContratos = FindPDFContratos.FirstOrDefault();
                            app.PDFContratos.Remove(pDFContratos);
                            await app.SaveChangesAsync();
                        }
                    }

                    string FileExt = Path.GetExtension(model.FileView.FileName);
                    Stream _Stream = model.FileView.InputStream;
                    BinaryReader binaryReader = new BinaryReader(_Stream);
                    byte[] File = binaryReader.ReadBytes((int)_Stream.Length);

                    var contratos = new Contratos() { Id = model.Contratos.Id };
                    db.Contratos.Attach(contratos);

                    model.File = File;
                    model.NameFile = model.FileView.FileName;
                    model.Contratos = contratos;
                    db.PDFContratos.Add(model);
                    db.SaveChanges();

                    var FinalResult = db.PDFContratos.ToList().LastOrDefault();

                    using (AppDbContext app = new AppDbContext())
                    {
                        var RegisterContratos = new ModifiedContratos
                        {
                            ExecutedAction = $"Se anexó al contrato el archivo{FinalResult.NameFile}",
                            ActionHour = DateTime.Now,
                            EmailUser = User.Identity.GetUserName(),
                            IdUser = User.Identity.GetUserId(),
                            ClaveContrato = model.Contratos.CLAVE_DEL_CONTRATO,
                        };

                        app.ModifiedContratos.Add(RegisterContratos);
                        await app.SaveChangesAsync();
                    }

                    ViewBag.Success = "Se guardaró el PDF correctamente.";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Por favor selecciona un archivo PDF.";
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> DisplayPDFContratos(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var Contratos = db.Contratos.Find(Id);

            if (Contratos == null)
                return HttpNotFound();

            //PORQUE ES 1-N PERO DEBERÍA SER 1-1 (CHECAR CON EL CLIENTE)
            var PDFContratos = Contratos.PDFContratos.FirstOrDefault();

            if (PDFContratos == null)
            {
                ViewBag.Error = "No existe PDF para este contrato.";
                return View("ViewContratos");
            }
            using (AppDbContext app = new AppDbContext())
            {
                var RegisterContratos = new ModifiedContratos
                {
                    ExecutedAction = $"Consultó el PDF el archivo {PDFContratos.NameFile}",
                    ActionHour = DateTime.Now,
                    EmailUser = User.Identity.GetUserName(),
                    IdUser = User.Identity.GetUserId(),
                    ClaveContrato = Convert.ToString(Id),
                };

                app.ModifiedContratos.Add(RegisterContratos);
                await app.SaveChangesAsync();
            }
            byte[] byteArray = PDFContratos.File;
            MemoryStream PDFStream = new MemoryStream();
            PDFStream.Write(byteArray, 0, byteArray.Length);
            PDFStream.Position = 0;

            return File(PDFStream, "application/pdf");
        }

        [HttpGet]
        public async Task<FileResult> CreaPDF()
        {
            MemoryStream ms = new MemoryStream();

            byte[] byteStream = ExportPDF.CreatePdf(db.Contratos.ToList(), ms).ToArray();
            ms = new MemoryStream();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;
            using (AppDbContext app = new AppDbContext())
            {
                var RegisterContratos = new ModifiedContratos
                {
                    ExecutedAction = $"Generó un archivo PDF",
                    ActionHour = DateTime.Now,
                    EmailUser = User.Identity.GetUserName(),
                    IdUser = User.Identity.GetUserId(),
                    ClaveContrato = null,
                };

                app.ModifiedContratos.Add(RegisterContratos);
                await app.SaveChangesAsync();
            }
            return new FileStreamResult(ms, "application/pdf");
        }
        [HttpGet]
        public ActionResult AdminCuentas()
        {

            return View(db.ManageAccounts.ToList());
        }

        [HttpGet]
        public ActionResult AdminMovimientos(string dato)
        {
            var lista = db.ModifiedContratos.Where(x => x.EmailUser == dato).ToList();
            var correos = context.Users.Select(x => x.Email).ToList();
            var cuentas = db.ManageAccounts.Select(x => x.EmailUser).ToList();

            DatosFiltrados model = new DatosFiltrados
            {
                ModifiedContratos = lista,
                usuarios = correos,
            };

           
            return View(model);
        }

    }
}

#region Comentarios
//for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
//{
//    for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
//    {
//        object cellValue = workSheet.Cells[i, j].Value;
//    }
//}
#endregion