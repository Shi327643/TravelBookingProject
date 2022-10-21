using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookingProject.Models;
namespace TravelBookingProject.ViewModel
{
    public class TravelViewModel { 
    
       
        public int? Request_No { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ManagerName { get; set; }
        public string ManagerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public DateTime Registed_Date { get; set; }
        [Required]
        [Display(Name = "Expected Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true/*, DataFormatString = "{0:yyyy-mmm-dd}"*/)]
        public DateTime Exp_Start_Date { get; set; }
        [Required]
        [Display(Name = "Expected End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true/*, DataFormatString = "{0:yyyy-mmm-dd}"*/)]
        public DateTime Exp_End_Date { get; set; }
        public string CityName { get; set; }
       
        public string Status { get; set; }
        public int GCMId { get; set; }
        public string GCM_Level { get; set; }
        public int TravelId { get; set; }
        public string Travel_Type { get; set; }





        //public IList<UserLogin> userList { get; set; }
        //public IList<Employee> EmpList { get; set; }
        //public IList<Country> countryList { get; set; }
        //public IList<City> cityList { get; set; }
        //public IList<GCM> GCMList { get; set; }
        //public IList<Travel> travelList { get; set; }
        //public IList<Travelers> travlersList { get; set; }
        //public IList<TravelViewModel> managerList { get; set; }
        public IEnumerable<SelectListItem> GCMItem { get; set; }
        public IEnumerable<SelectListItem> TravelItem { get; set; }
        public IEnumerable<SelectListItem> hostCountryList { get; set; }
        public IEnumerable<SelectListItem> hostCityList { get; set; }



        //public TravelViewModel()
        //{
        //    userList = new List<UserLogin>();
        //    EmpList = new List<Employee>();
        //    countryList = new List<Country>();
        //    cityList = new List<City>();
        //    GCMList = new List<GCM>();
          
        //    travelList = new List<Travel>();
        //    travlersList = new List<Travelers>();
        //}

    }
}