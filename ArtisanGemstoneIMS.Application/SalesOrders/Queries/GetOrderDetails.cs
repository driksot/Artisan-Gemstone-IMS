using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.SalesOrders.Queries;

public class GetOrderDetailsQuery : IRequest<SalesOrderDetailsDto>
{
    public Guid Id { get; set; }
}

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, SalesOrderDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public GetOrderDetailsQueryHandler(
        IMapper mapper,
        ISalesOrderRepository salesOrderRepository)
    {
        _mapper = mapper;
        _salesOrderRepository = salesOrderRepository;
    }

    public async Task<SalesOrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var order = await _salesOrderRepository.GetWithDetailsByIdAsync(request.Id);

        if (order == null)
            throw new NotFoundException(nameof(order), request.Id);

        var orderDetailsDto = _mapper.Map<SalesOrderDetailsDto>(order);

        return orderDetailsDto;
    }
}
