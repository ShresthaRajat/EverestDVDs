using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Everest_DVD_Store.Models
{
    public class DVDCategories
    {
        [Key]
        [MaxLength(100)]
        public String DVDsCategory { get; set; }
        [Required]
      
        public int AgeRestricted { get; set; }
    }
}