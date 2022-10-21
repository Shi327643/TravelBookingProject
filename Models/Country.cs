using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBookingProject.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Column("CountryId", TypeName ="Varchar")]
        [MaxLength(20)]
        public string CountryId { get; set; }


        [Column("CountryName", TypeName = "Varchar")]
        [MaxLength(20)]
        public string CountryName { get; set; }
    }
}


