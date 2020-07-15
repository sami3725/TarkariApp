using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TarkariWala.Models;

namespace TarkariWala.Controllers
{
    public class MunicipalitiesController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Municipalities
        public ActionResult Index()
        {
            var municipalities = db.Municipalities.Include(m => m.District);
            return View(municipalities.ToList());
        }

        // GET: Municipalities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipality municipality = db.Municipalities.Find(id);
            if (municipality == null)
            {
                return HttpNotFound();
            }
            return View(municipality);
        }

        // GET: Municipalities/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName");
            return View();
        }

        // POST: Municipalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipalityID,MunicipalityName,DistrictID")] Municipality municipality)
        {
            if (ModelState.IsValid)
            {
                db.Municipalities.Add(municipality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", municipality.DistrictID);
            return View(municipality);
        }

        // GET: Municipalities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipality municipality = db.Municipalities.Find(id);
            if (municipality == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", municipality.DistrictID);
            return View(municipality);
        }

        // POST: Municipalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipalityID,MunicipalityName,DistrictID")] Municipality municipality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", municipality.DistrictID);
            return View(municipality);
        }

        // GET: Municipalities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipality municipality = db.Municipalities.Find(id);
            if (municipality == null)
            {
                return HttpNotFound();
            }
            return View(municipality);
        }

        // POST: Municipalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipality municipality = db.Municipalities.Find(id);
            db.Municipalities.Remove(municipality);
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

        public ActionResult DistrictsCreateModal()
        {
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DistrictsCreateModal([Bind(Include = "DistrictID,DistrictName,StateID")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Create","Municipalities");
            }

            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", district.StateID);
            return View(district);
        }
    }
}
