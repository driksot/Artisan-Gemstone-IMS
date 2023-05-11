using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Queries;

public record GetInventoriesListQuery : IRequest<List<InventoriesListDto>>;

public class GetInventoriesListQueryHandler : IRequestHandler<GetInventoriesListQuery, List<InventoriesListDto>>
{
    private readonly IMapper _mapper;
    private readonly IInventoryRepository _inventoryRepository;

    public GetInventoriesListQueryHandler(
        IMapper mapper,
        IInventoryRepository inventoryRepository)
    {
        _mapper = mapper;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<List<InventoriesListDto>> Handle(GetInventoriesListQuery request, CancellationToken cancellationToken)
    {
        var inventories = (await _inventoryRepository.GetCurrentInventoryWithDetailsAsync()).ToList();
        var invetoriesListDtos = _mapper.Map<List<InventoriesListDto>>(inventories);
        return invetoriesListDtos;
    }
}
