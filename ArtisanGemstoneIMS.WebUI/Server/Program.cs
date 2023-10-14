using ArtisanGemstoneIMS.Application;
using ArtisanGemstoneIMS.Infrastructure.Persistence;
using ArtisanGemstoneIMS.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplicationServices();
    builder.Services.AddPersistenceServices(builder.Configuration);
    builder.Services.AddIdentityServices(builder.Configuration);

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    builder.Services.AddOpenApiDocument(config =>
        config.Title = "Artisan Gemstone IMS API");
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.UseReDoc(configure => configure.Path = "/redoc");

    app.UseRouting();
    app.MapRazorPages();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}
