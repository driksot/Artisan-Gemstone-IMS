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

    public async Task<IReadOnlyList<InventorySnapshot>> GetSnapshotHistoryAsync(int numberOfDays = 5)
    {
        var earliest = DateTime.Now - TimeSpan.FromDays(numberOfDays);

        return await _context.InventorySnapshots
            .Include(i => i.Product)
            .Where(i => i.SnapshotTime > earliest && !i.Product!.IsArchived)
            .ToListAsync();
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

            try
            {
                CreateSnapshot();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void CreateSnapshot()
    {
        var inventories = _context.Inventories
            .Include(i => i.Product)
            .ToList();

        foreach (var inv in inventories)
        {
            var snapshot = new InventorySnapshot
            {
                Product = inv.Product,
                ProductId = inv.ProductId,
                SnapshotTime = DateTime.Now,
                SnapshotQuantity = inv.QuantityOnHand
            };

            _context.Add(snapshot);
        }
    }
}
