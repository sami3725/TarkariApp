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
    public class DeliveryInformationsController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: DeliveryInformations
        public ActionResult Index()
        {
            var deliveryInformations = db.DeliveryInformations.Include(d => d.Deliveryman).Include(d => d.Order);
            return View(deliveryInformations.ToList());
        }

        // GET: DeliveryInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryInformation deliveryInformation = db.DeliveryInformations.Find(id);
            if (deliveryInformation == null)
            {
                return HttpNotFound();
            }
            return View(deliveryInformation);
        }

        // GET: DeliveryInformations/Create
        public ActionResult Create()
        {
            ViewBag.DeliverymansID = new SelectList(db.Deliverymen, "DeliverymansID", "DeliverymanName");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime");
            return View();
        }

        // POST: DeliveryInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryInformationID,OrderID,DeliverymansID,Signature")] DeliveryInformation deliveryInformation)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryInformations.Add(deliveryInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliverymansID = new SelectList(db.Deliverymen, "DeliverymansID", "DeliverymanName", deliveryInformation.DeliverymansID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime", deliveryInformation.OrderID);
            return View(deliveryInformation);
        }

        // GET: DeliveryInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryInformation deliveryInformation = db.DeliveryInformations.Find(id);
            if (deliveryInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliverymansID = new SelectList(db.Deliverymen, "DeliverymansID", "DeliverymanName", deliveryInformation.DeliverymansID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime", deliveryInformation.OrderID);
            return View(deliveryInformation);
        }

        // POST: DeliveryInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryInformationID,OrderID,DeliverymansID,Signature")] DeliveryInformation deliveryInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliverymansID = new SelectList(db.Deliverymen, "DeliverymansID", "DeliverymanName", deliveryInformation.DeliverymansID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime", deliveryInformation.OrderID);
            return View(deliveryInformation);
        }

        // GET: DeliveryInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryInformation deliveryInformation = db.DeliveryInformations.Find(id);
            if (deliveryInformation == null)
            {
                return HttpNotFound();
            }
            return View(deliveryInformation);
        }

        // POST: DeliveryInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryInformation deliveryInformation = db.DeliveryInformations.Find(id);
            db.DeliveryInformations.Remove(deliveryInformation);
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

        public ActionResult OrdersCreateModal()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Image");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrdersCreateModal([Bind(Include = "OrderID,ClientID,ProductID,DeliveryTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", order.ClientID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Image", order.ProductID);
            return View(order);
        }
        public ActionResult DeliverymenCreateModal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeliverymenCreateModal([Bind(Include = "DeliverymansID,DeliverymanName,Address,PhoneNo,CitizenshipNo")] Deliveryman deliveryman)
        {
            if (ModelState.IsValid)
            {
                db.Deliverymen.Add(deliveryman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryman);
        }
    }
}
