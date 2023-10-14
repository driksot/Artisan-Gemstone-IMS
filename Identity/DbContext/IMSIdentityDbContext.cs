using ArtisanGemstoneIMS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtisanGemstoneIMS.Infrastructure.Identity.DbContext;

public class IMSIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public IMSIdentityDbContext(DbContextOptions<IMSIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(IMSIdentityDbContext).Assembly);
    }
}
