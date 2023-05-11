using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Queries;

public class GetInventoryDetailsQuery : IRequest<InventoryDetailsDto>
{
    public Guid Id { get; set; }
}

public class GetInventoryDetailsQueryHandler : IRequestHandler<GetInventoryDetailsQuery, InventoryDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IInventoryRepository _inventoryRepository;

    public GetInventoryDetailsQueryHandler(
        IMapper mapper,
        IInventoryRepository inventoryRepository)
    {
        _mapper = mapper;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<InventoryDetailsDto> Handle(GetInventoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetWithDetailsByProductIdAsync(request.Id);

        if (inventory == null)
            throw new NotFoundException(nameof(inventory), request.Id);

        var inventoryDetailsDto = _mapper.Map<InventoryDetailsDto>(inventory);

        return inventoryDetailsDto;
    }
}
