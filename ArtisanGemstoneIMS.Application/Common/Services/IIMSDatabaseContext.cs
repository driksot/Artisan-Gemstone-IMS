using ArtisanGemstoneIMS.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Application.Common.Services;

public interface IIMSDatabaseContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
