using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
       
        public string Name { get; set; }
        public DateTime DOB { get; set; }
       
        public string Gender { get; set; }
       
        public string Address { get; set; }
      
        public string Phone { get; set; }
      
        public string Email { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual MemberCategory Categories { get; set; }
        public virtual IEnumerable<Loan> Loans { get; set; }

    }
}