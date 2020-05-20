using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.CastMember> CastMembers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.DVDDetail> DVDDetails { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.DVDProducer> DVDProducers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Producer> Producers { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Loan> Loans { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.DVDProducerActors> DVDProducerActors { get; set; }
    }
}