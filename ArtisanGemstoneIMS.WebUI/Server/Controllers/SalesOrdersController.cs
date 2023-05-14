using ArtisanGemstoneIMS.Application.SalesOrders.Commands;
using ArtisanGemstoneIMS.Application.SalesOrders.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtisanGemstoneIMS.WebUI.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesOrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesOrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<SalesOrdersController>/open
    [HttpGet("open")]
    public async Task<ActionResult<List<SalesOrdersListDto>>> GetOpenOrders()
    {
        var openOrders = await _mediator.Send(new GetOpenOrdersListQuery());
        return Ok(openOrders);
    }

    // GET: api/<SalesOrdersController>/closed
    [HttpGet("closed")]
    public async Task<ActionResult<List<SalesOrdersListDto>>> GetClosedOrders()
    {
        var closedOrders = await _mediator.Send(new GetClosedOrdersListQuery());
        return Ok(closedOrders);
    }

    // GET: api/<SalesOrdersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SalesOrderDetailsDto>> GetById(Guid id)
    {
        var order = await _mediator.Send(new GetOrderDetailsQuery { Id = id });
        return Ok(order);
    }

    // POST: api/<SalesOrdersController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GenerateOrder(GenerateOrderCommand order)
    {
        var response = await _mediator.Send(order);
        return CreatedAtAction(nameof(GetOpenOrders), new { id = response });
    }

    // PATCH: api/<SalesOrdersController>/5
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> MarkFulfilled(Guid id)
    {
        var command = new MarkOrderFulfilledCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
