using ArtisanGemstoneIMS.Domain.Products;

namespace ArtisanGemstoneIMS.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IReadOnlyList<Product>> GetUnArchivedAsync();
    Task ArchiveAsync(Guid id);
    Task CreateProductWithInventory(Product product);
}
