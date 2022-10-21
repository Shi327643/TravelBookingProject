using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelBookingProject.Models;
using TravelBookingProject.ViewModel;

namespace TravelBookingProject.Controllers
{
    


    public class LoginPageController : Controller
    {
        //TravelViewModel model;
        LoginContext db = new LoginContext();
        
        // GET: LoginPage
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginpageViewModel user)
        {
            
            if (ModelState.IsValid)
            {
                
               

                
                var data = (from e in db.UserLogins where e.UserName == user.UserName && e.Password == user.Password select e);
                

                if (data.Count()>0)
                {
                    var query = (from e in db.UserLogins where e.UserName == user.UserName && e.Password == user.Password select new { e.EmpId }).SingleOrDefault();
                    Session["empid"] = query.EmpId;

                    return RedirectToAction("TravelBooking","TravelBooking");
                   

                }
                else
                {
                    
                    ModelState.AddModelError("name", "Invalid UserName or Password.");
                  
                   

                    return View("Validate", user);
                }

            }
            return View("Validate", user);

        }

      

        
       
        
        

    }
}