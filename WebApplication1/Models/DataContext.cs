using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataContext() : base("name=DataContext")
        {
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Producer> Producers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.DVDDetail> DVDDetails { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Loan> Loans { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.CastMember> CastMembers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.DVDProducer> DVDProducers { get; set; }
    }
}
