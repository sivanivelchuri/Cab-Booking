using RegisterLoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RegisterLoginMVC.Controllers
{

    public class DashboardController : Controller
 
    {
        cab_bookingEntities db = new cab_bookingEntities();

        // GET: Dashboard

        
        public ActionResult Index(int userid)
        {
            var u = db.Users.Find(userid);
            return View(u);
        }



        public ActionResult CarDetails()
        {
           
            return View(db.CarModels);
        }
        public ActionResult BookNow(int CarId,string CarName,int Seats)
        {
            CarModel model = new CarModel();
            ViewBag.CarId = CarId;
            ViewBag.CarName=CarName;
            ViewBag.Seats = Seats;
            return View();
        }
        [HttpPost]
        public ActionResult BookNow(BookingList bookinglist)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                    BookingList book = new BookingList();
                    book.UserId = bookinglist.UserId;
                    book.AdminId = bookinglist.AdminId;
                    book.CarId = bookinglist.CarId;
                    book.CARName = bookinglist.CARName;
                    book.Seats = bookinglist.Seats;
                    //book.PickUp = bookinglist.PickUp;
                    //book.Drop = bookinglist.Drop;
                    book.PickUpDate = bookinglist.PickUpDate;
                    //if (book.PickUp=="Hyderabad" && book.Drop == "Pune")
                    //{
                    //    book.Fare = 1500;                       

                    //}
                    //else
                    //{
                    //    book.Fare = 3000;
                    //}

                    book.PickUp = bookinglist.PickUp;
                    book.Drop = bookinglist.Drop;
                    bookinglist.Fare = CalculateFare(bookinglist.PickUp, bookinglist.Drop);


                    book.PickUPTime = bookinglist.PickUPTime;
                    book.Status = "ToBeConfirmed";
                    db.BookingLists.Add(book);
                    db.SaveChanges();
                    bookinglist=new BookingList();
                    return RedirectToAction("Index", "Dashboard",new{ book.UserId});
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        private List<SelectListItem> GetPickUpList()
        {
            return new List<SelectListItem>
             {
             new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" },
             new SelectListItem { Text = "Bangalore", Value = "Bangalore" },
             new SelectListItem { Text = "Pune", Value = "Pune" },
             new SelectListItem { Text = "Chennai", Value = "Chennai" }
                    // Add more options as needed
             };
        }



        private List<SelectListItem> GetDropList()
        {
            return new List<SelectListItem>
             {
             new SelectListItem { Text = "Delhi", Value = "Delhi" },
             new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" },
             new SelectListItem { Text = "Bangalore", Value = "Bangalore" },
             new SelectListItem { Text = "Pune", Value = "Pune" },
             new SelectListItem { Text = "Chennai", Value = "Chennai" }
                    // Add more options as needed
             };
        }



        private int CalculateFare(string pickUp, string drop)
        {
            if ((pickUp == "Hyderabad" && drop == "Delhi") || (pickUp == "Delhi" && drop == "Hyderabad"))
            {
                return 15000;
            }
            else if ((pickUp == "Bangalore" && drop == "Hyderabad") || (pickUp == "Hyderabad" && drop == "Bangalore"))
            {
                return 10000;
            }
            else if ((pickUp == "Pune" && drop == "Hyderabad") || (pickUp == "Hyderabad" && drop == "Pune"))
            {
                return 10000;
            }
            else if ((pickUp == "Chennai" && drop == "Hyderabad") || (pickUp == "Hyderabad" && drop == "Chennai"))
            {
                return 10000;
            }
            else if ((pickUp == "Chennai" && drop == "Delhi") || (pickUp == "Delhi" && drop == "Chennai"))
            {
                return 20000;
            }
            else if ((pickUp == "Pune" && drop == "Chennai") || (pickUp == "Chennai" && drop == "Pune"))
            {
                return 17000;
            }
            else if ((pickUp == "Bangalore" && drop == "Chennai") || (pickUp == "Chennai" && drop == "Bangalore"))
            {
                return 8000;
            }
            else if ((pickUp == "Bangalore" && drop == "Delhi") || (pickUp == "Delhi" && drop == "Bangalore"))
            {
                return 8000;
            }



            return 0; // Default fare value if no condition matches
        }

        public ActionResult MyBookingList(int UserId)
        {
            try
            {
                User user = new User();
                List<BookingList> bookings = new List<BookingList>();
                bookings = db.BookingLists.Where(b => b.UserId == UserId).ToList();

                // Calculate and set the fare for each booking
                foreach (var booking in bookings)
                {
                    booking.Fare = CalculateFare(booking.PickUp, booking.Drop);
                }

                return View(bookings);
            }
            catch (Exception ex)
            {
                // Error handling code
            }

            return View();

        }
        /*
        public ActionResult MyBookingList()
        {
            
           // Get the current user's ID (you need to implement this logic)
          //  bookings = db.BookingLists.Where(b => b.UserId == UserId).ToList();
            return View(db.BookingLists);
            /* User user = db.Users.FirstOrDefault(u => u.UserId == UserId);
             if (user != null)
             {
                 List<BookingList> bookings = db.BookingLists.Where(b => b.UserId == UserId).ToList();
                 return View(bookings);
             }*/
            
        }
    }
    
