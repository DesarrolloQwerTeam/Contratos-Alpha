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
    public class ManageAccountsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageAccounts
        public ActionResult Index()
        {
            return View(db.ManageAccounts.ToList());
        }

        // GET: ManageAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageAccount manageAccount = db.ManageAccounts.Find(id);
            if (manageAccount == null)
            {
                return HttpNotFound();
            }
            return View(manageAccount);
        }

        // GET: ManageAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoginHour,LogoutHour,EmailUser,IdUser")] ManageAccount manageAccount)
        {
            if (ModelState.IsValid)
            {
                db.ManageAccounts.Add(manageAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manageAccount);
        }

        // GET: ManageAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageAccount manageAccount = db.ManageAccounts.Find(id);
            if (manageAccount == null)
            {
                return HttpNotFound();
            }
            return View(manageAccount);
        }

        // POST: ManageAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoginHour,LogoutHour,EmailUser,IdUser")] ManageAccount manageAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manageAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manageAccount);
        }

        // GET: ManageAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageAccount manageAccount = db.ManageAccounts.Find(id);
            if (manageAccount == null)
            {
                return HttpNotFound();
            }
            return View(manageAccount);
        }

        // POST: ManageAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManageAccount manageAccount = db.ManageAccounts.Find(id);
            db.ManageAccounts.Remove(manageAccount);
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
