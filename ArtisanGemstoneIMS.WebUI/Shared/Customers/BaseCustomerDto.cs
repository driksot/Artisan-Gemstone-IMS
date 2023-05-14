namespace ArtisanGemstoneIMS.WebUI.Shared.Customers;

public class BaseCustomerDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public AddressDto PrimaryAddress { get; set; } = new AddressDto();
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
