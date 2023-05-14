using ArtisanGemstoneIMS.Domain.SalesOrders;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;

namespace ArtisanGemstoneIMS.Application.SalesOrders;

public class SalesOrderMapping : Profile
{
    public SalesOrderMapping()
    {
        CreateMap<SalesOrder, SalesOrdersListDto>();
        CreateMap<SalesOrder, SalesOrderDetailsDto>();
    }
}
