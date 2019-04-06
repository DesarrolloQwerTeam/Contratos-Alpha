using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contratos_vers_beta.Controllers
{
    public class SerialController : Controller
    {
        // GET: Serial
        public ActionResult Index()
        {
            return View();
        }

        // GET: Serial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Serial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serial/Create
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

        // GET: Serial/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Serial/Edit/5
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

        // GET: Serial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Serial/Delete/5
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
