using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace StomatologyMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Cabinet> Cabinets { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}