using ArtisanGemstoneIMS.Domain.PurchaseOrders;

namespace ArtisanGemstoneIMS.Application.Contracts.Persistence;

public interface IPurchaseOrderRepository : IGenericRepository<PurchaseOrder>
{
    Task<IReadOnlyList<PurchaseOrder>> GetOrdersAsync();
    Task<PurchaseOrder> GetWithDetailsByIdAsync(Guid id);
    Task GenerateOrderAsync(PurchaseOrder order);
}
