using ArtisanGemstoneIMS.Application.SalesOrders.Commands;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;

namespace ArtisanGemstoneIMS.WebUI.Client.MappingProfiles;

public class SalesOrderMapping : Profile
{
    public SalesOrderMapping()
    {
        CreateMap<SalesOrderDetailsDto, GenerateOrderCommand>();
    }
}
