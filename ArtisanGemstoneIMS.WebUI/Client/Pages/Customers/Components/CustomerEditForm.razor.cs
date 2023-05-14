using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Customers.Components;

public partial class CustomerEditForm
{
    [Parameter]
    public CustomerDetailsDto Customer { get; set; } = null!;

    [Parameter]
    public EventCallback<CustomerDetailsDto> OnValidSubmit { get; set; }

    public async Task HandleValidSubmit()
    {
        await OnValidSubmit.InvokeAsync(Customer);
    }
}