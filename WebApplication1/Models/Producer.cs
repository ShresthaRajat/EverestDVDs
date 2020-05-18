using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
      
        public string ProducerName { get; set; }

        public DateTime DOB { get; set; }
      
        public string Gender { get; set; }

        public virtual IEnumerable<DVDDetail> DVDDetails { get; set; }
    }
}