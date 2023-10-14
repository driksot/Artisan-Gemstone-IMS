using ArtisanGemstoneIMS.Domain.Inventories;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using AutoMapper;

namespace ArtisanGemstoneIMS.Application.Inventories;

public class InventoryMapping : Profile
{
	public InventoryMapping()
	{
		CreateMap<Inventory, InventoriesListDto>();
		CreateMap<Inventory, InventoryDetailsDto>();
		CreateMap<InventorySnapshot, SnapshotDto>();
	}
}
