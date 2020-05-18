using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Everest_DVD_Store.Models
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]

        public string Phone { get; set; }
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }
        public string MemberCategoryId { get; set; }

        [ForeignKey("MemberCategoryId")]
        public virtual MembershipCategories MemberCategorys { get; set; }
    }
}