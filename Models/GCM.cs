using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBookingProject.Models
{
    [Table("GCM")]
    public class GCM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int GCMId { get; set; }

        
        [Column("GCM_Level", TypeName = "Varchar")]
        [MaxLength(20)]
        public string GCM_Level { get; set; }

    }
}

