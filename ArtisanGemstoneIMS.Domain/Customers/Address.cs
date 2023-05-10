using ArtisanGemstoneIMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ArtisanGemstoneIMS.Domain.Customers;

public class Address : AuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }

    [Required]
    [MaxLength(50)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string State { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(80)]
    public string Country { get; set; } = string.Empty;
}
