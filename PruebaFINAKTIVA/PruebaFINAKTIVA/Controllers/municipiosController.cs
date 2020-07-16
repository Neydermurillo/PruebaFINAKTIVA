using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaFINAKTIVA.Models;

namespace PruebaFINAKTIVA.Controllers
{
    public class municipiosController : Controller
    {
        private PruebaFinaktivaEntities1 db = new PruebaFinaktivaEntities1();

        // GET: municipios
        public ActionResult Index()
        {
            var municipios = db.municipios.Include(m => m.regiones);
            return View(municipios.ToList());
        }

        // GET: municipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipios municipios = db.municipios.Find(id);
            if (municipios == null)
            {
                return HttpNotFound();
            }
            return View(municipios);
        }

        // GET: municipios/Create
        public ActionResult Create()
        {
            ViewBag.codigo_region = new SelectList(db.regiones, "codigo_region", "nombre_region");
            return View();
        }

        // POST: municipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo_mupio,nombre_mupio,estado,codigo_region")] municipios municipios)
        {
            if (ModelState.IsValid)
            {
                db.municipios.Add(municipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_region = new SelectList(db.regiones, "codigo_region", "nombre_region", municipios.codigo_region);
            return View(municipios);
        }

        // GET: municipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipios municipios = db.municipios.Find(id);
            if (municipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_region = new SelectList(db.regiones, "codigo_region", "nombre_region", municipios.codigo_region);
            return View(municipios);
        }

        // POST: municipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo_mupio,nombre_mupio,estado,codigo_region")] municipios municipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_region = new SelectList(db.regiones, "codigo_region", "nombre_region", municipios.codigo_region);
            return View(municipios);
        }

        // GET: municipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipios municipios = db.municipios.Find(id);
            if (municipios == null)
            {
                return HttpNotFound();
            }
            return View(municipios);
        }

        // POST: municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            municipios municipios = db.municipios.Find(id);
            db.municipios.Remove(municipios);
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
