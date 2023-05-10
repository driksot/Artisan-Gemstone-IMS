using ArtisanGemstoneIMS.Domain.Common;
using ArtisanGemstoneIMS.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence;

public class IMSDatabaseContext : DbContext
{
    public IMSDatabaseContext(DbContextOptions<IMSDatabaseContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMSDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<AuditableEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.UpdatedAt = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
