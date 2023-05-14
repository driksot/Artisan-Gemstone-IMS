using ArtisanGemstoneIMS.Domain.SalesOrders;

namespace ArtisanGemstoneIMS.Application.Contracts.Persistence;

public interface ISalesOrderRepository : IGenericRepository<SalesOrder>
{
    Task<IReadOnlyList<SalesOrder>> GetOpenOrdersAsync();
    Task<IReadOnlyList<SalesOrder>> GetClosedOrdersAsync();
    Task<SalesOrder> GetWithDetailsByIdAsync(Guid id);
    Task MarkFulfilledAsync(Guid id);
}
