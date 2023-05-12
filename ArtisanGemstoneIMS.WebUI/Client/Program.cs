using ArtisanGemstoneIMS.WebUI.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICustomersClient, CustomersClient>();
builder.Services.AddScoped<IInventoriesClient, InventoriesClient>();
builder.Services.AddScoped<IProductsClient, ProductsClient>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMudServices();

await builder.Build().RunAsync();
