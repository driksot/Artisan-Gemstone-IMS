using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Home;

public partial class CustomerCount
{
    [Inject]
    public ICustomersClient CustomersClient { get; set; } = null!;

    private int Count = 0;

    protected override async Task OnInitializedAsync()
    {
        var products = await CustomersClient.GetAllAsync();
        Count = products.Count();
    }
}