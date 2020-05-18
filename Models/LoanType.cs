using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Everest_DVD_Store.Models
{
    public class LoanType
    {
        [Key]
        [MaxLength(100)]
        public string Loan_Type { get; set; }

        [Required]
        public int LoanRate { get; set; }
    }
}