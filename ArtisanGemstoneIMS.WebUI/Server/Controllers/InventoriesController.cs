using ArtisanGemstoneIMS.Application.Inventories.Commands;
using ArtisanGemstoneIMS.Application.Inventories.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.Inventories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtisanGemstoneIMS.WebUI.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<InventoriesController>
    [HttpGet]
    public async Task<ActionResult<List<InventoriesListDto>>> GetAll()
    {
        var inventories = await _mediator.Send(new GetInventoriesListQuery());
        return Ok(inventories);
    }

    // GET api/<InventoriesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryDetailsDto>> GetByProductId(Guid id)
    {
        var inventory = await _mediator.Send(new GetInventoryDetailsQuery { Id = id });
        return Ok(inventory);
    }

    // PATCH api/<InventoriesController>/quantityOnHand
    [HttpPatch("quantityOnHand")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateQuantityOnHand([FromBody] InventoryAdjustmentDto inventoryAdjustment)
    {
        var command = new UpdateQuantityOnHandCommand
        {
            Id = inventoryAdjustment.InventoryId,
            Adjustment = inventoryAdjustment.Adjustment
        };
        await _mediator.Send(command);
        return NoContent();
    }

    // PATCH api/<InventoriesController>/idealQuantity
    [HttpPatch("idealQuantity")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateIdealQuantity([FromBody] InventoryAdjustmentDto inventoryAdjustment)
    {
        var command = new UpdateIdealQuantityCommand
        {
            Id = inventoryAdjustment.InventoryId,
            Adjustment = inventoryAdjustment.Adjustment
        };
        await _mediator.Send(command);
        return NoContent();
    }
}
