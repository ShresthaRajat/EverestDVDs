using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Everest_DVD_Store.Models
{
    public class Copies
    {
        [Key]
        public int CopyNumber { get; set; }
        [Required]
        public String DVDTilte { get; set; }

        //DVD Reference
        [ForeignKey("DVDTilte")]
        public virtual DVDs DVDz { get; set; }
    }
}