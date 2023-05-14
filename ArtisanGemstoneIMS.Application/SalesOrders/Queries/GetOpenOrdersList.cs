using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.SalesOrders.Queries;

public record GetOpenOrdersListQuery : IRequest<List<SalesOrdersListDto>>;

public class GetOpenOrdersListQueryHandler : IRequestHandler<GetOpenOrdersListQuery, List<SalesOrdersListDto>>
{
    private readonly IMapper _mapper;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public GetOpenOrdersListQueryHandler(
        IMapper mapper,
        ISalesOrderRepository salesOrderRepository)
    {
        _mapper = mapper;
        _salesOrderRepository = salesOrderRepository;
    }

    public async Task<List<SalesOrdersListDto>> Handle(GetOpenOrdersListQuery request, CancellationToken cancellationToken)
    {
        var openOrders = await _salesOrderRepository.GetOpenOrdersAsync();
        var openOrdersListDtos = _mapper.Map<List<SalesOrdersListDto>>(openOrders);
        return openOrdersListDtos;
    }
}
