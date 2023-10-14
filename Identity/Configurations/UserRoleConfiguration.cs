using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtisanGemstoneIMS.Infrastructure.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "e8c5fe17-c066-4e51-95f4-e77add0f5c92",
                UserId = "93258ed8-4d53-4b18-a3ca-3a86abaddfd1"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c5a9dfd7-82b6-4b43-8ccf-642e3e9bf79a",
                UserId = "815fc3b6-b601-491e-8930-594eca763587"
            });
    }
}
