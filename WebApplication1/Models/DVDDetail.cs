using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DVDDetail
    {
        [Key]
        public int DVDId { get; set; }
       
        public string Title { get; set; }
        
        public string Genre { get; set; }
        
        public int NoOfCopy { get; set; }
    
        public bool AgeRestriction { get; set; }
      
        public string StudioName { get; set; }
        public string DVDCover { get; set; }
        public string DateAdded { get; set; }

        public virtual IEnumerable<Actor> Actors { get; set; }
        public virtual IEnumerable<Producer> Producers { get; set; }
        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}