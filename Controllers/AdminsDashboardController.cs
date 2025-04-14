using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegisterLoginMVC;

namespace RegisterLoginMVC.Controllers
{
    public class AdminsDashboardController : Controller
    {
        private cab_bookingEntities db = new cab_bookingEntities();

        // GET: AdminsDashboard
        public ActionResult Index(int adminid)
        {
            Admin model= new Admin();
            if (db.Admins.Any(m => m.adminId == adminid))
            {

                var a = db.Admins.Find(adminid);
                return View(a);
            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult BookingReq(int adminid)
        {
            Admin user = new Admin();
            List<BookingList> bookings = new List<BookingList>();
            bookings = db.BookingLists.Where(b => b.AdminId == adminid).ToList();
            return View(bookings);

        }
        public ActionResult Confirmation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingList booking = db.BookingLists.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        /*
         public ActionResult Confirmation([Bind(Include = "Status")] BookingList booking)
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     db.Entry(booking).State = EntityState.Modified;
                     db.SaveChanges();
                     return RedirectToAction("Index");
                 }
                 return View(booking);
             }
             catch (Exception ex) { }
             return View(booking);
         }*/
        [HttpPost]
        public ActionResult Confirmation(BookingList ride)
        {
            // Update the ride status in the database
            BookingList existingRide = db.BookingLists.Find(ride.RideId);
            if (existingRide == null)
            {
                return HttpNotFound();
            }

            existingRide.Status = ride.Status;
            db.SaveChanges();

            return RedirectToAction("Index", "AdminsDashboard", new {existingRide.AdminId});
        }

    }
}
