using PasswordSecurity;
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
    public class ClientsController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.Address);
            return View(clients.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult userview()
        {
            var indexs = db.Clients.ToList();
            return View(indexs);
        }
        public ActionResult AdmineuserCreate(string UserName, string Password, string Role, HttpPostedFileBase Image)
        {
            Client c = new Client();
            c.Email = UserName;
            c.Password = PasswordStorage.CreateHash(Password);
            c.Role = Role;
            var filename = Path.GetFileName(Image.FileName);
            var path = Path.Combine(Server.MapPath("~/imgs"), filename);
            Image.SaveAs(path);
            c.Image = "/imgs/" + filename;
            db.Clients.Add(c);
            db.SaveChanges();
            return RedirectToAction("userview");
        }
        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,ClientName,AddressID,PermanentAddressID,TemporaryAddressID,PhoneNo,Location,Email,DateOfBirth,Gender,Code,RefferClientCode")] Client client)
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

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", client.AddressID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,ClientName,AddressID,PermanentAddressID,TemporaryAddressID,PhoneNo,Location,Email,DateOfBirth,Gender,Code,RefferClientCode")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", client.AddressID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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

        public ActionResult AddressesCreateModal()
        {
            ViewBag.MunicipalityID = new SelectList(db.Municipalities, "MunicipalityID", "MunicipalityName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressesCreateModal([Bind(Include = "AddressID,MunicipalityID,StreetAddress")] Address address)
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
    }
}
