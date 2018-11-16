using System;
using System.Threading;
using System.Threading.Tasks;
using iOSSpecialFeatures.MobileAppService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace iOSSpecialFeatures.MobileAppService.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactPhone> ContactPhoneNumbers { get; set; }

        public DbSet<ContactEmail> ContactEmailAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
