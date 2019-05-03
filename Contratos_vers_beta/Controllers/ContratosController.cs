using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contratos_vers_beta.Models;

namespace Contratos_vers_beta.Controllers
{
    [Authorize]
    public class ContratosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Authorize(Roles = "desarrollo")]
        // GET: Contratos
        public ActionResult Index()
        {
            return View(db.Contratos.ToList());
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contratos = db.Contratos.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CLAVE_DEL_CONTRATO,FECHA,EMPRESA,APODERADO,FIRMADO,EMPRESA_1,APODERADO_1,FIRMADO_1,EMPRESA_2,APODERADO_2,FIRMADO_2,CONTRAPRESTACION_IVA_INCLUIDO,VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO,ORIGINAL_O_COPIA,ANIO_DE_FIRMA,OBSERVACIONES")] Contrato contratos)
        {
            if (ModelState.IsValid)
            {
                db.Contratos.Add(contratos);
                db.SaveChanges();
                return RedirectToAction("ViewContratos", "Home");
            }

            return View(contratos);
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contratos = db.Contratos.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CLAVE_DEL_CONTRATO,FECHA,EMPRESA,APODERADO,FIRMADO,EMPRESA_1,APODERADO_1,FIRMADO_1,EMPRESA_2,APODERADO_2,FIRMADO_2,CONTRAPRESTACION_IVA_INCLUIDO,VIGENCIA_TAL_CUAL_ESTIPULA_EL_CONTRATO,ORIGINAL_O_COPIA,ANIO_DE_FIRMA,OBSERVACIONES")] Contrato contratos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewContratos", "Home");
            }
            return View(contratos);
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contratos = db.Contratos.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contratos = db.Contratos.Find(id);
            db.Contratos.Remove(contratos);
            db.SaveChanges();
            return RedirectToAction("ViewContratos", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
