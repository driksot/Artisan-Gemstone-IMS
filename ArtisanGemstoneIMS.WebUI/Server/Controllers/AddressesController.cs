using ArtisanGemstoneIMS.Application.Addresses.Commands;
using ArtisanGemstoneIMS.Application.Addresses.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtisanGemstoneIMS.WebUI.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<AddressesController>
    [HttpGet]
    public async Task<ActionResult<List<AddressDto>>> GetAll()
    {
        var addresses = await _mediator.Send(new GetAddressesListQuery());
        return Ok(addresses);
    }

    // GET: api/<AddressesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDto>> GetById(Guid id)
    {
        var address = await _mediator.Send(new GetAddressDetailsQuery { Id = id });
        return Ok(address);
    }

    // POST: api/<AddressesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Create(CreateAddressCommand address)
    {
        var response = await _mediator.Send(address);
        return CreatedAtAction(nameof(GetAll), new { id = response });
    }

    // PUT: api/<AddressesController>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(UpdateAddressCommand address)
    {
        await _mediator.Send(address);
        return NoContent();
    }
}
