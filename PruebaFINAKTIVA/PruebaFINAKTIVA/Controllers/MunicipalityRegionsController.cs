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
    public class MunicipalityRegionsController : Controller
    {
        private TestFinaktivaBDEntities db = new TestFinaktivaBDEntities();

        // GET: MunicipalityRegions
        public ActionResult Index()
        {
            var municipalityRegion = db.MunicipalityRegion.Include(m => m.Municipalitys).Include(m => m.Region);
            return View(municipalityRegion.ToList());
        }

        // GET: MunicipalityRegions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalityRegion municipalityRegion = db.MunicipalityRegion.Find(id);
            if (municipalityRegion == null)
            {
                return HttpNotFound();
            }
            return View(municipalityRegion);
        }

        // GET: MunicipalityRegions/Create
        public ActionResult Create()
        {
            ViewBag.MunicipalityId = new SelectList(db.Municipalitys, "MunicipalityId", "Name");
            ViewBag.RegionId = new SelectList(db.Region, "RegionId", "Name");
            return View();
        }

        // POST: MunicipalityRegions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipalyRegionId,MunicipalityId,RegionId")] MunicipalityRegion municipalityRegion)
        {
            if (ModelState.IsValid)
            {
                db.MunicipalityRegion.Add(municipalityRegion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipalityId = new SelectList(db.Municipalitys, "MunicipalityId", "Name", municipalityRegion.MunicipalityId);
            ViewBag.RegionId = new SelectList(db.Region, "RegionId", "Name", municipalityRegion.RegionId);
            return View(municipalityRegion);
        }

        // GET: MunicipalityRegions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalityRegion municipalityRegion = db.MunicipalityRegion.Find(id);
            if (municipalityRegion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipalityId = new SelectList(db.Municipalitys, "MunicipalityId", "Name", municipalityRegion.MunicipalityId);
            ViewBag.RegionId = new SelectList(db.Region, "RegionId", "Name", municipalityRegion.RegionId);
            return View(municipalityRegion);
        }

        // POST: MunicipalityRegions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipalyRegionId,MunicipalityId,RegionId")] MunicipalityRegion municipalityRegion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipalityRegion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipalityId = new SelectList(db.Municipalitys, "MunicipalityId", "Name", municipalityRegion.MunicipalityId);
            ViewBag.RegionId = new SelectList(db.Region, "RegionId", "Name", municipalityRegion.RegionId);
            return View(municipalityRegion);
        }

        // GET: MunicipalityRegions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalityRegion municipalityRegion = db.MunicipalityRegion.Find(id);
            if (municipalityRegion == null)
            {
                return HttpNotFound();
            }
            return View(municipalityRegion);
        }

        // POST: MunicipalityRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MunicipalityRegion municipalityRegion = db.MunicipalityRegion.Find(id);
            db.MunicipalityRegion.Remove(municipalityRegion);
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
