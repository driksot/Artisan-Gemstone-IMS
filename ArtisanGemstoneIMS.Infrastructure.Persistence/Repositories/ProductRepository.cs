using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(IMSDatabaseContext context) : base(context)
    {

    }

    public async Task ArchiveAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
            product.IsArchived = true;

        await _context.SaveChangesAsync();
    }

    public async Task CreateProductWithInventory(Product product)
    {
        _context.Add(product);

        //var newInventory = new Inventory
        //{
        //    ProductId = product.Id,
        //    Product = product,
        //    QuantityOnHand = 0,
        //    IdealQuantity = 0
        //};

        //_context.Inventories.Add(newInventory);

        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Product>> GetUnArchivedAsync()
    {
        var products = await _context.Products
            .Where(prod => prod.IsArchived == false)
            .ToListAsync();
        return products;
    }
}
