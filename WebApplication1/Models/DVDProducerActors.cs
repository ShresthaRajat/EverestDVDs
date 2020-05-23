using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DVDProducerActors
    {
        [Key]
        public int id { get; set; }
        public CastMember castMember { get; set; }
        public DVDProducer dVDProducer { get; set; }


    }
}