using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Commands;

public class UpdateQuantityOnHandCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public int Adjustment { get; set; }
}

public class UpdateQuantityOnHandCommandCommandHandler : IRequestHandler<UpdateQuantityOnHandCommand, Unit>
{
    private readonly IInventoryRepository _inventoryRepository;

    public UpdateQuantityOnHandCommandCommandHandler(
        IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<Unit> Handle(UpdateQuantityOnHandCommand request, CancellationToken cancellationToken)
    {
        await _inventoryRepository.UpdateUnitsAvailableAsync(request.Id, request.Adjustment);

        return Unit.Value;
    }
}
