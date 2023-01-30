using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class RegisterFormsController : Controller
    {
        private MyassgnmentEntities db = new MyassgnmentEntities();

        // GET: RegisterForms
        public ActionResult Index()
        {
            var registerForm = db.RegisterForm.Include(r => r.Client).Include(r => r.Service);
            return View(registerForm.ToList());
        }

        // GET: RegisterForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterForm registerForm = db.RegisterForm.Find(id);
            if (registerForm == null)
            {
                return HttpNotFound();
            }
            return View(registerForm);
        }

        // GET: RegisterForms/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "Name");
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "Name");
            return View();
        }

        // POST: RegisterForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegisterNo,ServiceTime,ClientId,ServiceId")] RegisterForm registerForm)
        {
            if (ModelState.IsValid)
            {
                db.RegisterForm.Add(registerForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "Name", registerForm.ClientId);
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "Name", registerForm.ServiceId);
            return View(registerForm);
        }

        // GET: RegisterForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterForm registerForm = db.RegisterForm.Find(id);
            if (registerForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "Name", registerForm.ClientId);
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "Name", registerForm.ServiceId);
            return View(registerForm);
        }

        // POST: RegisterForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegisterNo,ServiceTime,ClientId,ServiceId")] RegisterForm registerForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Client, "ClientId", "Name", registerForm.ClientId);
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "Name", registerForm.ServiceId);
            return View(registerForm);
        }

        // GET: RegisterForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterForm registerForm = db.RegisterForm.Find(id);
            if (registerForm == null)
            {
                return HttpNotFound();
            }
            return View(registerForm);
        }

        // POST: RegisterForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterForm registerForm = db.RegisterForm.Find(id);
            db.RegisterForm.Remove(registerForm);
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
