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
    public class PaymentsController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Client).Include(p => p.Order);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,OrderID,ClientID,CoupenCode,PayedAmount,Date,Code")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", payment.ClientID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime", payment.OrderID);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", payment.ClientID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime", payment.OrderID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,OrderID,ClientID,CoupenCode,PayedAmount,Date,Code")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", payment.ClientID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "DeliveryTime", payment.OrderID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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

        public ActionResult ClientsCreateModal()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientsCreateModal([Bind(Include = "ClientID,ClientName,AddressID,PermanentAddressID,TemporaryAddressID,PhoneNo,Location,Email,DateOfBirth,Gender,Code,RefferClientCode")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", client.AddressID);
            return View(client);
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
    }
}
