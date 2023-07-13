using ArtisanGemstoneIMS.Application.PurchaseOrders.Commands;
using ArtisanGemstoneIMS.Application.PurchaseOrders.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtisanGemstoneIMS.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PurchaseOrdersController>
        [HttpGet]
        public async Task<ActionResult<List<PurchaseOrderDto>>> GetPurchaseOrders()
        {
            var orders = await _mediator.Send(new GetPurchaseOrdersListQuery());
            return Ok(orders);
        }

        // GET api/<PurchaseOrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderDto>> GetPurchaseOrdersById(Guid id)
        {
            var order = await _mediator.Send(new GetPurchaseOrderDetailsQuery { Id = id });
            return Ok(order);
        }

        // POST api/<PurchaseOrdersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GeneratePurchaseOrder(GeneratePurchaseOrderCommand order)
        {
            var response = await _mediator.Send(order);
            return CreatedAtAction(nameof(GetPurchaseOrders), new { id = response });
        }
    }
}
