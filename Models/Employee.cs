using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBookingProject.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Column("EmpId",TypeName ="varchar")]
        [MaxLength(20)]
        public string EmpId { get; set; }

        [Column("EmpName", TypeName ="varchar")]
        [MaxLength(20)]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "ManagerId is Required")]
        [Column("ManagerId", TypeName = "varchar")]
        [MaxLength(20)]
        public string ManagerId { get; set; }
        [Required(ErrorMessage = "Country is Required")]
        [Column("Country", TypeName = "varchar")]
        [MaxLength(20)]
        public string  Country { get; set; }
        [Required(ErrorMessage = "City is Required")]
        [Column("City", TypeName = "varchar")]
        [MaxLength (20)]
        public string City { get; set; }



    }
}