using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBookingProject.Models
{
    [Table("Travel")]
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TravelId { get; set; }
        [Column("Travel_Type",TypeName ="varchar")]
        [MaxLength(20)]
        public string Travel_Type { get; set; }
    }
}