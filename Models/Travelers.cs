using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBookingProject.Models
{
    [Table("Travelers")]
    public class Travelers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Request_No { get; set; }
        [Column("EmpId",TypeName ="Varchar")]
        [MaxLength(20)]
        public string EmpId { get; set; }
        [ForeignKey("GCM")]
        [Required(ErrorMessage ="GCMId is Required")]
        public int GCMId { get; set; }
        public GCM GCM { get; set; }
        [ForeignKey("Travel")]
        [Required(ErrorMessage = "TravelId is Required")]
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        [ForeignKey("Country")]
        public string CountryId { get; set; }
        public Country Country { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
        public DateTime Registed_Date { get; set; }   
        public DateTime Exp_Start_Date { get; set; }
        public DateTime Exp_End_Date { get; set; }
        [Column("Status",TypeName ="Varchar")]
        [MaxLength(20)]
        public string Status { get; set; }
        [ForeignKey("Employee")]
        public string ManagerId { get; set; }
        public Employee Employee { get; set; }
    }
}