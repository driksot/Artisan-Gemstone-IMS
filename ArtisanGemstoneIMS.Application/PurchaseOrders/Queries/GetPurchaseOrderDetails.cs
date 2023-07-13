using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.PurchaseOrders.Queries;

public class GetPurchaseOrderDetailsQuery : IRequest<PurchaseOrderDto>
{
    public Guid Id { get; set; }
}

public class GetPurchaseOrderDetailsQueryHandler : IRequestHandler<GetPurchaseOrderDetailsQuery, PurchaseOrderDto>
{
    private readonly IMapper _mapper;
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrderDetailsQueryHandler(
        IMapper mapper,
        IPurchaseOrderRepository purchaseOrderRepository)
    {
        _mapper = mapper;
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<PurchaseOrderDto> Handle(GetPurchaseOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var order = await _purchaseOrderRepository.GetWithDetailsByIdAsync(request.Id);

        if (order == null)
        {
            throw new NotFoundException(nameof(order), request.Id);
        }

        var orderDetailsDto = _mapper.Map<PurchaseOrderDto>(order);

        return orderDetailsDto;
    }
}
