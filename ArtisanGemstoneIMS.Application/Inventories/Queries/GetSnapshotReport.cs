using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Queries;

public class GetSnapshotReportQuery : IRequest<List<SnapshotDto>>
{
    public int NumberOfDays { get; set; } = 5;
}

public class GetSnapshotReportQueryHandler : IRequestHandler<GetSnapshotReportQuery, List<SnapshotDto>>
{
    private readonly IMapper _mapper;
    private readonly IInventoryRepository _inventoryRepository;

    public GetSnapshotReportQueryHandler(
        IMapper mapper,
        IInventoryRepository inventoryRepository)
    {
        _mapper = mapper;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<List<SnapshotDto>> Handle(GetSnapshotReportQuery request, CancellationToken cancellationToken)
    {
        var history = await _inventoryRepository.GetSnapshotHistoryAsync(request.NumberOfDays);

        var snapshots = _mapper.Map<List<SnapshotDto>>(history);

        return snapshots;
    }
}
