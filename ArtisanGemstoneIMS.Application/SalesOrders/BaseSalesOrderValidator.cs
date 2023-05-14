using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using FluentValidation;

namespace ArtisanGemstoneIMS.Application.SalesOrders;

public class BaseSalesOrderValidator : AbstractValidator<BaseSalesOrderDto>
{
    public BaseSalesOrderValidator()
    {
        
    }
}
