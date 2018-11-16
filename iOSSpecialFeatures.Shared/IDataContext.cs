using System.Threading;
using System.Threading.Tasks;
using iOSSpecialFeatures.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace iOSSpecialFeatures.Shared
{
    public interface IDataContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactPhone> ContactPhoneNumbers { get; set; }
        DbSet<ContactEmail> ContactEmailAddresses { get; set; }
        DbSet<ChangeDataHash> DataChanges { get; set; }
        EntityEntry Entry(object entity);
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
    }
}