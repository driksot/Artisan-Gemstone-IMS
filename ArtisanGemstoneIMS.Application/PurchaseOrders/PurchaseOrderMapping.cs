using ArtisanGemstoneIMS.Application.PurchaseOrders.Commands;
using ArtisanGemstoneIMS.Domain.PurchaseOrders;
using ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;
using AutoMapper;

namespace ArtisanGemstoneIMS.Application.PurchaseOrders;

public class PurchaseOrderMapping : Profile
{
    public PurchaseOrderMapping()
    {
        CreateMap<PurchaseOrder, PurchaseOrderDto>();
        CreateMap<BasePurchaseOrderDto, PurchaseOrder>();
        CreateMap<GeneratePurchaseOrderCommand, PurchaseOrder>();
    }
}
