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
    [Authorize(Roles = "desarrollo")]
    public class PDFContratosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: PDFContratos
        public ActionResult Index()
        {
            return View(db.PDFContratos.ToList());
        }

        // GET: PDFContratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDFContratos pDFContratos = db.PDFContratos.Find(id);
            if (pDFContratos == null)
            {
                return HttpNotFound();
            }
            return View(pDFContratos);
        }

        // GET: PDFContratos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDFContratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameFile,File")] PDFContratos pDFContratos)
        {
            if (ModelState.IsValid)
            {
                db.PDFContratos.Add(pDFContratos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pDFContratos);
        }

        // GET: PDFContratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDFContratos pDFContratos = db.PDFContratos.Find(id);
            if (pDFContratos == null)
            {
                return HttpNotFound();
            }
            return View(pDFContratos);
        }

        // POST: PDFContratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameFile,File")] PDFContratos pDFContratos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pDFContratos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pDFContratos);
        }

        // GET: PDFContratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDFContratos pDFContratos = db.PDFContratos.Find(id);
            if (pDFContratos == null)
            {
                return HttpNotFound();
            }
            return View(pDFContratos);
        }

        // POST: PDFContratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PDFContratos pDFContratos = db.PDFContratos.Find(id);
            db.PDFContratos.Remove(pDFContratos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
