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
    public class DeliverymenController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Deliverymen
        public ActionResult Index()
        {
            return View(db.Deliverymen.ToList());
        }

        // GET: Deliverymen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveryman deliveryman = db.Deliverymen.Find(id);
            if (deliveryman == null)
            {
                return HttpNotFound();
            }
            return View(deliveryman);
        }

        // GET: Deliverymen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliverymen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliverymansID,DeliverymanName,Address,PhoneNo,CitizenshipNo")] Deliveryman deliveryman)
        {
            if (ModelState.IsValid)
            {
                db.Deliverymen.Add(deliveryman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryman);
        }

        // GET: Deliverymen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveryman deliveryman = db.Deliverymen.Find(id);
            if (deliveryman == null)
            {
                return HttpNotFound();
            }
            return View(deliveryman);
        }

        // POST: Deliverymen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliverymansID,DeliverymanName,Address,PhoneNo,CitizenshipNo")] Deliveryman deliveryman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryman);
        }

        // GET: Deliverymen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveryman deliveryman = db.Deliverymen.Find(id);
            if (deliveryman == null)
            {
                return HttpNotFound();
            }
            return View(deliveryman);
        }

        // POST: Deliverymen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deliveryman deliveryman = db.Deliverymen.Find(id);
            db.Deliverymen.Remove(deliveryman);
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
