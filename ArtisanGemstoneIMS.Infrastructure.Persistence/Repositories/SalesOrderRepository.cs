using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.SalesOrders;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IProductRepository _productRepository;

    public SalesOrderRepository(
        IMSDatabaseContext context,
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository) 
        : base(context)
    {
        _inventoryRepository = inventoryRepository;
        _productRepository = productRepository;
    }

    public async Task GenerateOrderAsync(SalesOrder order)
    {
        foreach (var item in order.LineItems)
        {
            // Adjust product inventory quantity
            var inventory = await _inventoryRepository.GetWithDetailsByProductIdAsync(item.ProductId);
            var adjustment = item.Quantity * -1;

            await _inventoryRepository.UpdateUnitsAvailableAsync(inventory.Id, adjustment);
        }

        _context.SalesOrders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<SalesOrder>> GetClosedOrdersAsync()
    {
        var orders = await _context.SalesOrders
            .Where(so => so.IsPaid == true)
            .Include(so => so.LineItems)
            .Include(so => so.Customer)
            .ToListAsync();
        return orders;
    }

    public async Task<IReadOnlyList<SalesOrder>> GetOpenOrdersAsync()
    {
        var orders = await _context.SalesOrders
            .Where(so => so.IsPaid == false)
            .Include(so => so.LineItems)
            .Include(so => so.Customer)
            .ToListAsync();
        return orders;
    }

    public async Task<SalesOrder> GetWithDetailsByIdAsync(Guid id)
    {
        var order = await _context.SalesOrders
            .Include(so => so.LineItems)
            .Include(so => so.Customer)
            .FirstOrDefaultAsync(so => so.Id == id);
        return order;
    }

    public async Task MarkFulfilledAsync(Guid id)
    {
        var order = await _context.SalesOrders.FindAsync(id);

        if (order != null)
            order.IsPaid = true;

        await _context.SaveChangesAsync();
    }
}
