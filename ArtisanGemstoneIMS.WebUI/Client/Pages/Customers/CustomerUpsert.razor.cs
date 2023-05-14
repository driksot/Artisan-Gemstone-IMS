using ArtisanGemstoneIMS.Application.Addresses.Commands;
using ArtisanGemstoneIMS.Application.Customers.Commands;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using AutoMapper;
using Microsoft.AspNetCore.Components;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Customers;

public partial class CustomerUpsert
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    [Inject]
    public ICustomersClient CustomersClient { get; set; } = null!;

    [Inject]
    public IAddressesClient AddressesClient { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public IMapper Mapper { get; set; } = null!;

    private CustomerDetailsDto Customer = new CustomerDetailsDto();
    private string Title = "Add";

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        if (Id.Length > 1)
        {
            Title = "Edit";
            Customer = await CustomersClient.GetByIdAsync(Guid.Parse(Id));
        }
    }

    private async Task HandleValidSubmit(CustomerDetailsDto customer)
    {
        if (Id.Length > 1)
        {
            var updateAddress = Mapper.Map<UpdateAddressCommand>(customer.PrimaryAddress);
            await AddressesClient.UpdateAsync(updateAddress);

            var updateCustomer = Mapper.Map<UpdateCustomerCommand>(customer);
            await CustomersClient.UpdateAsync(updateCustomer);
        }
        else
        {
            var createCustomer = Mapper.Map<CreateCustomerCommand>(customer);
            await CustomersClient.CreateAsync(createCustomer);
        }

        NavigationManager.NavigateTo("/customers");
    }
}