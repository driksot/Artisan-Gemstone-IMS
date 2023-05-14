using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.SalesOrders.Queries;

public record GetClosedOrdersListQuery : IRequest<List<SalesOrdersListDto>>;

public class GetClosedOrdersListQueryHandler : IRequestHandler<GetClosedOrdersListQuery, List<SalesOrdersListDto>>
{
    private readonly IMapper _mapper;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public GetClosedOrdersListQueryHandler(
        IMapper mapper,
        ISalesOrderRepository salesOrderRepository)
    {
        _mapper = mapper;
        _salesOrderRepository = salesOrderRepository;
    }

    public async Task<List<SalesOrdersListDto>> Handle(GetClosedOrdersListQuery request, CancellationToken cancellationToken)
    {
        var closedOrders = await _salesOrderRepository.GetClosedOrdersAsync();
        var closedOrdersListDtos = _mapper.Map<List<SalesOrdersListDto>>(closedOrders);
        return closedOrdersListDtos;
    }
}
