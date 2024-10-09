
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure;

public class CollectionScheduleDbContext : DbContext, ICollectionScheduleDbContext
{
    public CollectionScheduleDbContext(DbContextOptions<CollectionScheduleDbContext> options) : base(options)
    {}

    public DbSet<Address> Addresses { get; set; }
    public DbSet<CollectionSchedule> CollectionSchedules { get; set; }

    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes().Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
        {
            modelBuilder.Entity(entity.Name).Property("CreatedAt").HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity(entity.Name).Property("UpdatedAt").HasDefaultValueSql("GETUTCDATE()");
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

}
