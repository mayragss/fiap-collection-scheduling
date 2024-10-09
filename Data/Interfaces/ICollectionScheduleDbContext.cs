using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces;

public interface ICollectionScheduleDbContext
{
    DbSet<Address> Addresses { get; set; }
    DbSet<CollectionSchedule> CollectionSchedules { get; set; }
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
