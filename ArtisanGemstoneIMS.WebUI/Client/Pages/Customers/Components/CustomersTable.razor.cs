using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Customers.Components;

public partial class CustomersTable
{
    [Inject]
    public ICustomersClient CustomersClient { get; set; } = null!;

    private string searchString = "";
    private CustomersListDto selectedCustomer = new CustomersListDto();
    private IEnumerable<CustomersListDto> Customers = new List<CustomersListDto>();

    protected override async Task OnInitializedAsync()
    {
        Customers = await CustomersClient.GetAllAsync();
    }

    private bool FilterFunc(CustomersListDto customer) => FilterFunction(customer, searchString);

    private bool FilterFunction(CustomersListDto customer, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (customer.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (customer.PrimaryAddress.AddressLine1.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (customer.PrimaryAddress.State.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (customer.CreatedAt.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{customer.LastName} {customer.PrimaryAddress.AddressLine1} {customer.PrimaryAddress.State} {customer.CreatedAt}".Contains(searchString))
            return true;
        return false;
    }
}