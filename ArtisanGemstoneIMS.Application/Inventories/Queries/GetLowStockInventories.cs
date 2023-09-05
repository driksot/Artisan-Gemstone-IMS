using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Queries;

public record GetLowStockInventoriesQuery : IRequest<List<InventoriesListDto>>;

public class GetLowStockInventoriesQueryHandler : IRequestHandler<GetLowStockInventoriesQuery, List<InventoriesListDto>>
{
    private readonly IMapper _mapper;
    private readonly IInventoryRepository _inventoryRepository;

    public GetLowStockInventoriesQueryHandler(
        IMapper mapper,
        IInventoryRepository inventoryRepository)
    {
        _mapper = mapper;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<List<InventoriesListDto>> Handle(GetLowStockInventoriesQuery request, CancellationToken cancellationToken)
    {
        var inventories = (await _inventoryRepository.GetLowStockInventories()).ToList();
        var inventoriesListDtos = _mapper.Map<List<InventoriesListDto>>(inventories);
        return inventoriesListDtos;
    }
}
