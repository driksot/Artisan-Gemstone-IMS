using ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;
using FluentValidation;

namespace ArtisanGemstoneIMS.Application.PurchaseOrders;

public class BasePurchaseOrderValidator : AbstractValidator<BasePurchaseOrderDto>
{
    public BasePurchaseOrderValidator()
    {
        
    }
}
