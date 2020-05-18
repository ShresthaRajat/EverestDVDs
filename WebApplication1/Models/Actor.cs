using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
       
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Photo { get; set; }
       
        public DateTime DOB { get; set; }
       
        public string Gender { get; set; }
     
        public string Nationality { get; set; }

        public virtual IEnumerable<DVDDetail> DVDDetails { get; set; }
    }
}