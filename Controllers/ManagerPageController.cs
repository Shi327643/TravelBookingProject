using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelBookingProject.Models;
using TravelBookingProject.ViewModel;

namespace TravelBookingProject.Controllers
{
    public class ManagerPageController : Controller
    {
        LoginContext db = new LoginContext();
        ManagerPageViewModel managerObj;
        // GET: ManagerPage
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManagerLogin(LoginpageViewModel manager)
        {
            if (ModelState.IsValid)
            {
                var query = (from m in db.Managers where m.DasId == manager.DasId && m.Password == manager.Password select m).Count();
                if (query > 0)
                {
                    var data = (from e in db.Managers where e.DasId == manager.DasId  && e.Password == manager.Password select new { e.ManagerId }).SingleOrDefault();
                    Session["managerid"] = data.ManagerId;
                    return RedirectToAction("ManagerApproval", "ManagerPage");
                }
                else
                {
                    ModelState.AddModelError("name", "Invalid DasId or Password");
                }
            }

            return View("ManagerLogin", manager);
        }

       



        [HttpGet]
        
        public ActionResult ManagerApproval()
        {
            managerObj = new ManagerPageViewModel();

            if (Session["managerid"] == null)
            {
                return HttpNotFound();
            }
            string managerid = Session["managerid"].ToString();
           var query = (from t in db.Travelers join e in db.Employees on t.EmpId equals e.EmpId where t.ManagerId == managerid select new ManagerPageViewModel { EmpId = t.EmpId, EmpName = e.EmpName, Registed_Date=t.Registed_Date, Status = t.Status}).ToList();

            
            
            
            return View(query);
        }
        
        [HttpPost]
        public ActionResult ApproveRequest(string id)
        {

            if (ModelState.IsValid)
            {
                Travelers travelObj = new Travelers();
                travelObj = (from t in db.Travelers where t.EmpId == id && t.Status == "Pending" select t).FirstOrDefault();
                if(travelObj != null)
                {
                    travelObj.Status = "Approved";
                    db.Entry(travelObj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    TempData["ErrorMessage"] = "***The action(Approve/Reject) has been already performed***";
                }

            }
           

            return RedirectToAction("ManagerApproval", "ManagerPage");
        }
        [HttpPost]
        public ActionResult RejectRequest(string id)
        {
            if (ModelState.IsValid)
            {
                Travelers travelObj = new Travelers();

                travelObj = (from t in db.Travelers where t.EmpId == id && t.Status == "Pending" select t).FirstOrDefault();

                if(travelObj != null)
                {
                    travelObj.Status = "Rejected";

                    db.Entry(travelObj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    TempData["ErrorMessage"] = "***The action(Approve/Reject) has been already performed***";
                }

            }


            return RedirectToAction("ManagerApproval", "ManagerPage");
        }
    }
}