using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;

namespace ArtisanGemstoneIMS.WebUI.Client.MappingProfiles;

public class InventoryMapping : Profile
{
    public InventoryMapping()
    {
        CreateMap<SnapshotResponse, SnapshotResponseVM>().ReverseMap();
        CreateMap<SnapshotVM, SnapshotChartVM>().ReverseMap();
    }
}
