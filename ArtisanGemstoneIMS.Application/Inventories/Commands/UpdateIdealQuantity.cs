using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Inventories.Commands;

public class UpdateIdealQuantityCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public int Adjustment { get; set; }
}

public class UpdateIdealQuantityCommandHandler : IRequestHandler<UpdateIdealQuantityCommand, Unit>
{
    private readonly IInventoryRepository _inventoryRepository;

    public UpdateIdealQuantityCommandHandler(
        IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<Unit> Handle(UpdateIdealQuantityCommand request, CancellationToken cancellationToken)
    {
        await _inventoryRepository.UpdateIdealQuantityAsync(request.Id, request.Adjustment);

        return Unit.Value;
    }
}
