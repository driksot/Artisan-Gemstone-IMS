using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.SalesOrders.Components;

public partial class AddressLine
{
    [Parameter]
    public CustomerDetailsDto Customer { get; set; } = new CustomerDetailsDto();
}