using Contratos_vers_beta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contratos_vers_beta.Controllers
{
    public class BufeteController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Bufete
        public ActionResult Index()
        {
            var model = db.Bufetes.ToList();
            return View();
        }

        // GET: Bufete/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bufete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bufete/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bufete/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bufete/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bufete/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bufete/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
