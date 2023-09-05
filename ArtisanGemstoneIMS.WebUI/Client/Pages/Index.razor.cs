using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ArtisanGemstoneIMS.WebUI.Client.Pages;

public partial class Index
{
    [Inject]
    public IInventoriesClient InventoriesClient { get; set; } = null!;

    [Inject]
    public IProductsClient ProductsClient { get; set; } = null!;

    [Inject]
    public IMapper Mapper { get; set; } = null!;

    private int SelectedIndex = -1; //default value cannot be 0 -> first selectedindex is 0.
    private SnapshotResponseVM _snapshots = new SnapshotResponseVM();
    private readonly ChartOptions _options = new ChartOptions();

    public List<ChartSeries> Series { get; set; } = new List<ChartSeries>();
    public string[] XAxisLabels = new string[0];

    protected override async Task OnInitializedAsync()
    {
        var snapshots = await InventoriesClient.GetSnapshotHistoryAsync(2);
        _snapshots = Mapper.Map<SnapshotResponseVM>(snapshots);

        foreach (var snapshot in _snapshots.InventorySnapshots)
        {
            var product = await ProductsClient.GetByIdAsync(snapshot.ProductId);

            Series.Add(new ChartSeries()
            {
                Name = product.Name,
                Data = snapshot.QuantityOnHand
            });
        }

        XAxisLabels = _snapshots.Timeline.Select(time => time.ToShortDateString()).ToArray();
        _options.YAxisTicks = 5;
    }
}