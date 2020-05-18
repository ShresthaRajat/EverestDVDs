using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Everest_DVD_Store.Models
{
    public class Loans
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int CopyId { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string LoanType { get; set; }


        //Artists Reference
        [ForeignKey("MemberId")]
        public virtual Members Memberz { get; set; }

        [ForeignKey("LoanType")]
        public virtual LoanType LoanTypes { get; set; }


        //Movie Reference
        [ForeignKey("CopyId")]
        public virtual Copies Copiez { get; set; }
    }
}