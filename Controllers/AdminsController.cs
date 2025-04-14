using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegisterLoginMVC;
using RegisterLoginMVC.Models;

namespace RegisterLoginMVC.Controllers
{
    public class AdminsController : Controller
    {
        private cab_bookingEntities db = new cab_bookingEntities();

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        public ActionResult Register()
        {
            Admin obj = new Admin();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Register(Admin obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!db.Admins.Any(m => m.aEmailId == obj.aEmailId))
                    {
                        Admin admin = new Admin();
                        admin.aEmailId = obj.aEmailId;
                        admin.aName = obj.aName;
                        admin.aPassword = obj.aPassword;
                        admin.aMobile = obj.aMobile;
                        db.Admins.Add(admin);
                        db.SaveChanges();
                        obj = new Admin();
                        return RedirectToAction("Login", "Admins");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Email is Already Exists!");
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        public ActionResult Login()
        {
            Admin obj = new Admin();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (!db.Admins.Any(m => m.aEmailId == admin.aEmailId && m.aPassword == admin.aPassword))
                {
                    ModelState.AddModelError("Error", "Invalid Email and Password.");
                    return View();
                }
                else
                {
                    var ad = db.Admins.FirstOrDefault(m => m.aEmailId == admin.aEmailId);
                    int Adminid = ad.adminId;
                    Session["Email"] = admin.aEmailId;
                    return RedirectToAction("Index", "AdminsDashboard", new {adminid=Adminid});
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
