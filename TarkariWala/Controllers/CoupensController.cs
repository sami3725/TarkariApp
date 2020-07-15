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
    public class CoupensController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Coupens
        public ActionResult Index()
        {
            return View(db.Coupens.ToList());
        }

        // GET: Coupens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupen coupen = db.Coupens.Find(id);
            if (coupen == null)
            {
                return HttpNotFound();
            }
            return View(coupen);
        }

        // GET: Coupens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoupenID,CoupenName,Amount,CoupenCode")] Coupen coupen)
        {
            if (ModelState.IsValid)
            {
                db.Coupens.Add(coupen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coupen);
        }

        // GET: Coupens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupen coupen = db.Coupens.Find(id);
            if (coupen == null)
            {
                return HttpNotFound();
            }
            return View(coupen);
        }

        // POST: Coupens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoupenID,CoupenName,Amount,CoupenCode")] Coupen coupen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coupen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coupen);
        }

        // GET: Coupens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupen coupen = db.Coupens.Find(id);
            if (coupen == null)
            {
                return HttpNotFound();
            }
            return View(coupen);
        }

        // POST: Coupens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coupen coupen = db.Coupens.Find(id);
            db.Coupens.Remove(coupen);
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
