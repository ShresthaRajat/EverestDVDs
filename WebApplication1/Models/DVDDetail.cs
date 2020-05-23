using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public string NoOfCopy { get; set; }
    
        public string AgeRestriction { get; set; }
      
        public string StudioName { get; set; }
        [DisplayName("DVD Cover")]
        public string DVDCoverPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase DVDCoverFile { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual IEnumerable<Actor> Actors { get; set; }
        public virtual IEnumerable<Producer> Producers { get; set; }
        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}