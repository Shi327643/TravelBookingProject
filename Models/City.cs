using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingProject.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int CityId { get; set; }

        
        [Column("CityName", TypeName = "Varchar")]
        [MaxLength(20)]
        public string CityName { get; set; }



        [ForeignKey("Country")]
        [Column("CountryId",TypeName ="Varchar")]
        [MaxLength(20)]
        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}

