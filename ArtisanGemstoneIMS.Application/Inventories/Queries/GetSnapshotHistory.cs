using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Queries;

public class GetSnapshotHistoryQuery : IRequest<SnapshotResponse>
{
    public int NumberOfDays { get; set; } = 2;
}

public class GetSnapshotHistoryQueryHandler : IRequestHandler<GetSnapshotHistoryQuery, SnapshotResponse>
{
    private readonly IInventoryRepository _inventoryRepository;

    public GetSnapshotHistoryQueryHandler(
        IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<SnapshotResponse> Handle(GetSnapshotHistoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var history = await _inventoryRepository.GetSnapshotHistoryAsync(request.NumberOfDays);

            var timelineMarkers = history
                .Select(t => t.SnapshotTime)
                .Distinct()
                .ToList();

            var snapshots = history
                .GroupBy(h => h.Product, h => h.SnapshotQuantity,
                    (key, g) => new SnapshotVM
                    {
                        QuantityOnHand = g.ToList(),
                        ProductId = key.Id
                    })
                .OrderBy(h => h.ProductId)
                .ToList();

            var viewModel = new SnapshotResponse
            {
                InventorySnapshots = snapshots,
                Timeline = timelineMarkers
            };

            return viewModel;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception();
        }
    }
}
