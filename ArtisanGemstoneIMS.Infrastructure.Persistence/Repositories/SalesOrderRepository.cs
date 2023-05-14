using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.SalesOrders;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;

public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
{
    public SalesOrderRepository(IMSDatabaseContext context) : base(context)
    {
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
