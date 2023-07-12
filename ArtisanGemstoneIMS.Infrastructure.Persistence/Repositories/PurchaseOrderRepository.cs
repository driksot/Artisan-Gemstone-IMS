using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.PurchaseOrders;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
{
    private readonly IInventoryRepository _inventoryRepository;

    public PurchaseOrderRepository(
        IMSDatabaseContext context,
        IInventoryRepository inventoryRepository) 
        : base(context)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task GenerateOrderAsync(PurchaseOrder order)
    {
        foreach (var item in order.LineItems)
        {
            // Adjust product inventory quantity
            var inventory = await _inventoryRepository.GetWithDetailsByProductIdAsync(item.ProductId);
            var adjustment = item.Quantity;

            await _inventoryRepository.UpdateUnitsAvailableAsync(inventory.ProductId, adjustment);
        }

        _context.PurchaseOrders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<PurchaseOrder>> GetOrdersAsync()
    {
        var orders = await _context.PurchaseOrders
            .Include(po => po.LineItems)
            .ToListAsync();
        return orders;
    }

    public async Task<PurchaseOrder> GetWithDetailsByIdAsync(Guid id)
    {
        var order = await _context.PurchaseOrders
            .Include(po => po.LineItems)
            .FirstOrDefaultAsync(po => po.Id == id);

        if (order == null) return new PurchaseOrder();

        return order;
    }
}
