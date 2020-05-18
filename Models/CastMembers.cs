using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Everest_DVD_Store.Models
{
    public class CastMembers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ActorId { get; set; }
        [Required]
        public string DVDTitle { get; set; }

        //Artists Reference
        [ForeignKey("ActorId")]
        public virtual Actors Actorz { get; set; }


        //Album Reference
        [ForeignKey("DVDTitle ")]
        public virtual DVDs DVDz { get; set; }
    }
}
