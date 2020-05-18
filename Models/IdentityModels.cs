using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Everest_DVD_Store.Models
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

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.Actors> Actors { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.CastMembers> CastMembers { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.DVDs> DVDs { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.Copies> Copies { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.DVDCategories> DVDCategories { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.Loans> Loans { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.LoanType> LoanTypes { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.Members> Members { get; set; }

        public System.Data.Entity.DbSet<Everest_DVD_Store.Models.MembershipCategories> MembershipCategories { get; set; }
    }
}