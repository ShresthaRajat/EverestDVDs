using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MemberCategory
    {
        [Key]
        public int CategoryId { get; set; }
    
        public string Name { get; set; }
        
        public string Description { get; set; }
  
        public int TotalLoan { get; set; }
      
        public int TotalKeepDays { get; set; }
        
        public int Fine { get; set; }

        public virtual IEnumerable<Member> Members { get; set; }
    }
}