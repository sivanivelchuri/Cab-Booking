using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegisterLoginMVC;
using RegisterLoginMVC.DBModel;
using RegisterLoginMVC.Models;

namespace RegisterLoginMVC.Controllers
{
    public class AdminRegsController : Controller
    {
        private DXC_trainingEntities db = new DXC_trainingEntities();

        // GET: AdminRegs
        public ActionResult Index()
        {
            return View(db.AdminRegs.ToList());
        }

        // GET: AdminRegs/Details/5
   

        // GET: AdminRegs/Create
        public ActionResult Register()
        {
            
            AdminReg obj = new AdminReg();
            return View(obj);
        }

        // POST: AdminRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AdminReg adminReg)
        {
            if (ModelState.IsValid)
            {
                if (!DXC_trainingEntities.AdminRegister.Any(m => m.Email == adminReg.Email))
                {
                    User objAdmin = new DBModel.User();
                    objAdmin.Name = objAdmin.Name;
                    objAdmin.Email = objAdmin.Email;


                    objAdmin.Password = objAdmin.Password;
                    DXC_trainingEntities.AdminReg.Add(o);
                    DXC_trainingEntities.SaveChanges();
                    adminReg = new AdminReg();
                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email is Already Exists!");
                    return View();
                }
            }
            return View();
        }

        // GET: AdminRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminReg adminReg = db.AdminRegs.Find(id);
            if (adminReg == null)
            {
                return HttpNotFound();
            }
            return View(adminReg);
        }

        // POST: AdminRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password")] AdminReg adminReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminReg);
        }

        // GET: AdminRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminReg adminReg = db.AdminRegs.Find(id);
            if (adminReg == null)
            {
                return HttpNotFound();
            }
            return View(adminReg);
        }

        // POST: AdminRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminReg adminReg = db.AdminRegs.Find(id);
            db.AdminRegs.Remove(adminReg);
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
