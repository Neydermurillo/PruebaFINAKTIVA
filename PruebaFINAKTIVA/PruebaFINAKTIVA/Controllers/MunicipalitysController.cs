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
    public class MunicipalitysController : Controller
    {
        private TestFinaktivaBDEntities db = new TestFinaktivaBDEntities();

        // GET: Municipalitys
        public ActionResult Index()
        {
            return View(db.Municipalitys.ToList());
        }

        // GET: Municipalitys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipalitys municipalitys = db.Municipalitys.Find(id);
            if (municipalitys == null)
            {
                return HttpNotFound();
            }
            return View(municipalitys);
        }

        // GET: Municipalitys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Municipalitys/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipalityId,Name,State")] Municipalitys municipalitys)
        {
            if (ModelState.IsValid)
            {
                db.Municipalitys.Add(municipalitys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(municipalitys);
        }

        // GET: Municipalitys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipalitys municipalitys = db.Municipalitys.Find(id);
            if (municipalitys == null)
            {
                return HttpNotFound();
            }
            return View(municipalitys);
        }

        // POST: Municipalitys/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipalityId,Name,State")] Municipalitys municipalitys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipalitys).State = EntityState.Modified;
                db.SaveChanges();

                if(!municipalitys.State)
                {
                    var regions = db.MunicipalityRegion.Where(r => r.MunicipalityId == municipalitys.MunicipalityId);
                    if (regions.Count() > 0)
                    {
                        db.MunicipalityRegion.RemoveRange(regions);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(municipalitys);
        }

        // GET: Municipalitys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipalitys municipalitys = db.Municipalitys.Find(id);
            if (municipalitys == null)
            {
                return HttpNotFound();
            }
            return View(municipalitys);
        }

        // POST: Municipalitys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipalitys municipalitys = db.Municipalitys.Find(id);
            db.Municipalitys.Remove(municipalitys);
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
