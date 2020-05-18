using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Everest_DVD_Store.Models
{
    public class DVDs
    {
        [Key]
        public string DVDTitle { get; set; }
        [Required]
        [MaxLength(100)]
       
        public string DVDStudio { get; set; }
        public string DVDProducer { get; set; }
        public string RunTime { get; set; }
        public String DVDsCategory { get; set; }
        //DVD Reference
        [ForeignKey("DVDsCategory")]
        public virtual DVDs DVDz { get; set; }

        public DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<Actors> Actorz { get; set; }
    }
}