using iOSSpecialFeatures.Shared;
using iOSSpecialFeatures.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace iOSSpecialFeatures.MobileAppService.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactPhone> ContactPhoneNumbers { get; set; }

        public DbSet<ContactEmail> ContactEmailAddresses { get; set; }

        public DbSet<ChangeDataHash> DataChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
