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
    public class GifCardsController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: GifCards
        public ActionResult Index()
        {
            return View(db.GifCards.ToList());
        }

        // GET: GifCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GifCard gifCard = db.GifCards.Find(id);
            if (gifCard == null)
            {
                return HttpNotFound();
            }
            return View(gifCard);
        }

        // GET: GifCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GifCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GifCardID,GifCardName,Amount,Code")] GifCard gifCard)
        {
            if (ModelState.IsValid)
            {
                db.GifCards.Add(gifCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gifCard);
        }

        // GET: GifCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GifCard gifCard = db.GifCards.Find(id);
            if (gifCard == null)
            {
                return HttpNotFound();
            }
            return View(gifCard);
        }

        // POST: GifCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GifCardID,GifCardName,Amount,Code")] GifCard gifCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gifCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gifCard);
        }

        // GET: GifCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GifCard gifCard = db.GifCards.Find(id);
            if (gifCard == null)
            {
                return HttpNotFound();
            }
            return View(gifCard);
        }

        // POST: GifCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GifCard gifCard = db.GifCards.Find(id);
            db.GifCards.Remove(gifCard);
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
