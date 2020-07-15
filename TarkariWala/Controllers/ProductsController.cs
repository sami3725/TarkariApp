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
    public class ProductsController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductSubCategory).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductSubCategoryID = new SelectList(db.ProductSubCategories, "ProductSubCategoryID", "ProductSubCategoryName");
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "SuppliersID", "SuppliersName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductSubCategoryID,SuppliersID,Quantity,Discount")] Product product,HttpPostedFileBase Image)
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

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductSubCategoryID = new SelectList(db.ProductSubCategories, "ProductSubCategoryID", "ProductSubCategoryName", product.ProductSubCategoryID);
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "SuppliersID", "SuppliersName", product.SuppliersID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Image,ProductSubCategoryID,SuppliersID,Quantity,Discount")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductSubCategoryID = new SelectList(db.ProductSubCategories, "ProductSubCategoryID", "ProductSubCategoryName", product.ProductSubCategoryID);
            ViewBag.SuppliersID = new SelectList(db.Suppliers, "SuppliersID", "SuppliersName", product.SuppliersID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        public ActionResult ProductSubCategoriesCreateModal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductSubCategoriesCreateModal([Bind(Include = "ProductSubCategoryID,ProductSubCategoryName,Rate,Available,DisplayOrder,Image")] ProductSubCategory productSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductSubCategories.Add(productSubCategory);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(productSubCategory);
        }

        public ActionResult SuppliersCreateModal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuppliersCreateModal([Bind(Include = "SuppliersID,SuppliersName")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(supplier);
        }
    }
}
