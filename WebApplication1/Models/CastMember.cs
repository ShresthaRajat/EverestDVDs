using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CastMember
    {
        [Key]
        public int Id { get; set; }
       
        public int DVDId { get; set; }
       
        public int ActorId { get; set; }

        [ForeignKey("DVDId")]
        public virtual DVDDetail DVDDetails { get; set; }
        [ForeignKey("ActorId")]
        public virtual Actor Actors { get; set; }

    }
}