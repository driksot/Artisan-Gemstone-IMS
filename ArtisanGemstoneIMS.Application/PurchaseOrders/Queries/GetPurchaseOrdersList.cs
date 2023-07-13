using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.PurchaseOrders.Queries;

public record GetPurchaseOrdersListQuery : IRequest<List<PurchaseOrderDto>>;

public class GetPurchaseOrdersListQueryHandler : IRequestHandler<GetPurchaseOrdersListQuery, List<PurchaseOrderDto>>
{
    private readonly IMapper _mapper;
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GetPurchaseOrdersListQueryHandler(
        IMapper mapper,
        IPurchaseOrderRepository purchaseOrderRepository)
    {
        _mapper = mapper;
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<List<PurchaseOrderDto>> Handle(GetPurchaseOrdersListQuery request, CancellationToken cancellationToken)
    {
        var orders = await _purchaseOrderRepository.GetOrdersAsync();
        var ordersListDtos = _mapper.Map<List<PurchaseOrderDto>>(orders);
        return ordersListDtos;
    }
}
