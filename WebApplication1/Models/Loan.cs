using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int TotalFine { get; set; }
        public int DVDId { get; set; }
        [ForeignKey("DVDId")]
        public virtual DVDDetail DVDDetails { get; set; }

        [Required]
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }
    }
    public class LoanViewModel
    {
        [Key]
        public int id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string CName { get; set; }
        public int NumberOfLoans { get; set; }
        public string LoanStatus { get; set; }

    }
    public class Function12Model
    {
        [Key]
        public int id { get; set; }
        public Member member { get; set; }
        public DVDDetail dVDDetail { get; set; }
        public Loan loan { get; set; }

    }
}