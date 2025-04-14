using RegisterLoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace RegisterLoginMVC.Controllers
{
    public class AccountController : Controller
    {
        cab_bookingEntities objUserDBEntities =new cab_bookingEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!objUserDBEntities.Users.Any(m => m.EmailId == objUserModel.EmailId))
                    {
                        User objUser = new User();
                        objUser.EmailId = objUserModel.EmailId;
                        objUser.UserName = objUserModel.UserName;
                        objUser.Password = objUserModel.Password;
                        objUser.MobileNum = objUserModel.MobileNum; 
                        objUserDBEntities.Users.Add(objUser);
                        objUserDBEntities.SaveChanges();
                        objUserModel = new UserModel();
                        return RedirectToAction("Login", "Account");
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
            User objLoginModel=new User();
            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(User objLoginModel)
        {
            if(ModelState.IsValid)
            {
                if(!objUserDBEntities.Users.Any(m=>m.EmailId == objLoginModel.EmailId && m.Password == objLoginModel.Password))
                {
                    ModelState.AddModelError("Error", "Invalid Email and Password.");
                    return View();
                }
                else
                {
                   var user = objUserDBEntities.Users.FirstOrDefault(m => m.EmailId == objLoginModel.EmailId);
                    int userId = user.UserId;
                    Session["Email"] = objLoginModel.EmailId;
                    return RedirectToAction("Index", "Dashboard", new {userid=userId});
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}