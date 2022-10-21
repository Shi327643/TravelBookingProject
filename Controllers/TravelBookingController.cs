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
    
    public class TravelBookingController : Controller
    {
        TravelViewModel model;
        LoginContext db = new LoginContext();
        // GET: TravelBooking
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult TravelBooking()
        {
            model = new TravelViewModel();
            if (Session["empid"] == null)
            {
                return HttpNotFound();
            }

            string EmpId = Session["empid"].ToString();
            var data = (from e in db.Employees
                        join u in db.UserLogins on e.EmpId equals u.EmpId
                        where u.EmpId == EmpId
                        select new { e.EmpName, e.Country, e.City,e.ManagerId,e.EmpId}).SingleOrDefault();


            model.EmpName = data.EmpName;
            Session["EmpName"] = data.EmpName;
            model.Country = data.Country;
            model.City = data.City;
            model.ManagerId = data.ManagerId;
            var query1 = (from m in db.Managers where m.ManagerId == model.ManagerId select m).SingleOrDefault();
            Session["ManagerName"] = query1.ManagerName;
            model.ManagerName = query1.ManagerName;
            model.Status = "Pending";
            model.GCMItem = new SelectList(db.GCMs, "GCMId", "GCM_Level");
            model.TravelItem = new SelectList(db.Travels, "TravelId", "Travel_Type");
            model.hostCountryList = new SelectList(db.Countries, "CountryId", "CountryName");

            model.hostCityList = new SelectList(db.Cities, "CityId", "CityName");

           



            return View(model);
        }
        [HttpPost]
        public ActionResult TravelBooking(TravelViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Travelers travelObj = new Travelers();
                    travelObj.GCMId = model.GCMId;
                    travelObj.TravelId = model.TravelId;
                    travelObj.CountryId = model.CountryId;
                    travelObj.CityId = model.CityId;
                    travelObj.ManagerId = model.ManagerId;
                    
                    travelObj.Status = model.Status;
                    travelObj.Exp_Start_Date = model.Exp_Start_Date;
                    travelObj.Exp_End_Date = model.Exp_End_Date;
                    string EmpId = Session["empid"].ToString();
                    travelObj.EmpId = EmpId;
                    travelObj.Registed_Date = DateTime.Now;
                    db.Travelers.Add(travelObj);
                    db.SaveChanges();
                    return RedirectToAction("WelcomePage", "TravelBooking");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    if (ex.InnerException != null)
                    {
                        ViewBag.Errormsg = ex.InnerException.InnerException.Message;
                    }
                    return View(model);

                }

            }
            return View(model);

        }

        public ActionResult WelcomePage()
        {
            string name = Session["EmpName"].ToString();
            string managername = Session["ManagerName"].ToString();
            ViewBag.Message = "Thank You" + " " + name + " " + "for filling the booking form.";
            ViewBag.Message1 = "Your details has been shared to your manager" + " " + managername + " " + "for approval.";
            return View();
        }
        public JsonResult Cities(string countryId)
        {
            var cities = db.Cities.Where(x => x.CountryId == countryId).Select(m => new SelectListItem()
            {
                Text = m.CityName,
                Value = m.CityId.ToString(),
            });

            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(string id)
        {
            var query = (from t in db.Travelers
                         join e in db.Employees on t.EmpId equals e.EmpId
                         join g in db.GCMs on t.GCMId equals g.GCMId
                         join s in db.Travels on t.TravelId equals s.TravelId
                         join c in db.Countries on t.CountryId equals c.CountryId
                         join
                         y in db.Cities on t.CityId equals y.CityId
                         where t.EmpId == id
                         select new TravelViewModel
                         {
                             EmpName = e.EmpName,
                             EmpId = e.EmpId,
                             GCM_Level = g.GCM_Level,
                             Travel_Type = s.Travel_Type,
                             CountryName = c.CountryName,
                             CityName = y.CityName,
                             Exp_Start_Date = t.Exp_Start_Date,
                             Exp_End_Date = t.Exp_End_Date

                         }).FirstOrDefault();

            return View(query); 
        }

    }
}