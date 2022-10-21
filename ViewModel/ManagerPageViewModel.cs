using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBookingProject.Models;
namespace TravelBookingProject.ViewModel
{
    public class ManagerPageViewModel
    {
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string Status { get; set; }
        public string ManagerName { get; set; }
        public DateTime Registed_Date { get; set; }
        public int Request_No { get; set; }
        
       
        
    }
}