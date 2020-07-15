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
    public class AddressesController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.Municipality);
            return View(addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.MunicipalityID = new SelectList(db.Municipalities, "MunicipalityID", "MunicipalityName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,MunicipalityID,StreetAddress")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipalityID = new SelectList(db.Municipalities, "MunicipalityID", "MunicipalityName", address.MunicipalityID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipalityID = new SelectList(db.Municipalities, "MunicipalityID", "MunicipalityName", address.MunicipalityID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,MunicipalityID,StreetAddress")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipalityID = new SelectList(db.Municipalities, "MunicipalityID", "MunicipalityName", address.MunicipalityID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
        public ActionResult MunicipalitiesCreateModal()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName");
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MunicipaliesCreateModal([Bind(Include = "MunicipalityID,MunicipalityName,DistrictID")] Municipality municipality)
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
    }
}
    

