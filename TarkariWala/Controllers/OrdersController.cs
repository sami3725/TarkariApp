using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TarkariWala.Models;

namespace TarkariWala.Controllers
{
    public class OrdersController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Client).Include(o => o.Product);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Image");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ClientID,ProductID,DeliveryTime")] Order order)
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

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", order.ClientID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Image", order.ProductID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ClientID,ProductID,DeliveryTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", order.ClientID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Image", order.ProductID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
        public ActionResult ProductsCreateModal()
        {
            ViewBag.ProductSubCategoryID = new SelectList(db.ProductSubCategories, "ProductSubCategoryID", "ProductSubCategoryName");
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "SuppliersID", "SuppliersName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductsCreateModal([Bind(Include = "ProductID,ProductSubCategoryID,SuppliersID,Quantity,Discount")] Product product, HttpPostedFileBase Image)
        {

            ViewBag.ProductSubCategoryID = new SelectList(db.ProductSubCategories, "ProductSubCategoryID", "ProductSubCategoryName", product.ProductSubCategoryID);
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "SuppliersID", "SuppliersName", product.SuppliersID);

            if (ModelState.IsValid)
            {
                var tempimg = Image;
                var file = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("/Image"), file);
                tempimg.SaveAs(path);
                product.Image = "/Image/" + file;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(product);
        }
    }
}
