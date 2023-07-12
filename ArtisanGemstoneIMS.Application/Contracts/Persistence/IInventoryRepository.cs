using ArtisanGemstoneIMS.Domain.Inventories;

namespace ArtisanGemstoneIMS.Application.Contracts.Persistence;

public interface IInventoryRepository : IGenericRepository<Inventory>
{
    Task<Inventory> GetWithDetailsByProductIdAsync(Guid productId);
    Task<IReadOnlyList<Inventory>> GetCurrentInventoryWithDetailsAsync();
    Task UpdateUnitsAvailableAsync(Guid id, int adjustment);
    Task UpdateIdealQuantityAsync(Guid id, int adjustment);
    Task<IReadOnlyList<InventorySnapshot>> GetSnapshotHistoryAsync(int numberOfDays);
}
