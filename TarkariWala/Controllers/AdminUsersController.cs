using PasswordSecurity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TarkariWala.Models;

namespace TarkariWala.Controllers
{
    public class AdminUsersController : Controller
    {
        private Tarkari db = new Tarkari();

        // GET: AdminUsers
        public ActionResult Index()
        {
            return View(db.AdminUsers.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string UserName, string Password)
        {

            var count = db.AdminUsers.Where(x => x.UserName == UserName).SingleOrDefault();
            if (count == null)
            {
                ViewBag.Msg = "Invalid Login Attempt........";
                return View();
            }
            bool result = PasswordStorage.VerifyPassword(Password, count.Password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // GET: AdminUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // GET: AdminUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,UserName,Password,Role")] AdminUser adminUser)
        {
            if (ModelState.IsValid)
            {
                adminUser.Password = PasswordStorage.CreateHash(adminUser.Password);
                db.AdminUsers.Add(adminUser);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(adminUser);
        }

        // GET: AdminUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // POST: AdminUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,UserName,Password,Role")] AdminUser adminUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminUser);
        }

        // GET: AdminUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminUser = db.AdminUsers.Find(id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            return View(adminUser);
        }

        // POST: AdminUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminUser adminUser = db.AdminUsers.Find(id);
            db.AdminUsers.Remove(adminUser);
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
