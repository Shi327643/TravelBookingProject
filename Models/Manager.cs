using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBookingProject.Models
{
    [Table("Manager")]
    public class Manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        [Column("ManagerId", TypeName ="varchar")]
        [MaxLength(20)]
        public string ManagerId { get; set; }
        [Column("ManagerName", TypeName ="Varchar")]
        [MaxLength(20)]
        public string ManagerName { get; set; }
        [Required(ErrorMessage ="DasId is Required")]
        [Column("DasId",TypeName ="varchar")]
        [MaxLength(20)]
        public string DasId { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [Column("Password",TypeName ="varchar")]
        [MaxLength(20)]
        public string Password { get; set; }

    }
}