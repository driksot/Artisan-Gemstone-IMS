using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Inventories;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(IMSDatabaseContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Inventory>> GetCurrentInventoryWithDetailsAsync()
    {
        var inventories = await _context.Inventories
            .Include(i => i.Product)
            .ToListAsync();
        return inventories;
    }

    public async Task<Inventory> GetWithDetailsByProductIdAsync(Guid productId)
    {
        var inventory = await _context.Inventories
            .Include(i => i.Product)
            .FirstOrDefaultAsync(i => i.ProductId == productId);
        return inventory ?? new Inventory();
    }

    public async Task UpdateIdealQuantityAsync(Guid id, int adjustment)
    {
        try
        {
            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventory != null)
            {
                inventory.IdealQuantity += adjustment;
            }

            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task UpdateUnitsAvailableAsync(Guid id, int adjustment)
    {
        try
        {
            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventory != null)
            {
                inventory.QuantityOnHand += adjustment;
            }

            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
