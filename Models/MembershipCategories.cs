using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Everest_DVD_Store.Models
{
    public class MembershipCategories
    {
        [Key]
        [MaxLength(200)]
        public string MembershipCategory { get; set; }
        [Required]
        [MaxLength(100)]

        public string TotalLoan { get; set; }


    }
}