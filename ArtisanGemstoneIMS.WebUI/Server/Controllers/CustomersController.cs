using ArtisanGemstoneIMS.Application.Customers.Commands;
using ArtisanGemstoneIMS.Application.Customers.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtisanGemstoneIMS.WebUI.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<CustomersController>
    [HttpGet]
    public async Task<ActionResult<List<CustomersListDto>>> GetAll()
    {
        var customers = await _mediator.Send(new GetCustomersListQuery());
        return Ok(customers);
    }

    // GET: api/<CustomersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDetailsDto>> GetById(Guid id)
    {
        var customer = await _mediator.Send(new GetCustomerDetailsQuery { Id = id });
        return Ok(customer);
    }

    // POST: api/<CustomersController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Create(CreateCustomerCommand customer)
    {
        var response = await _mediator.Send(customer);
        return CreatedAtAction(nameof(GetAll), new { id = response });
    }

    // PUT: api/<CustomersController>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(UpdateCustomerCommand customer)
    {
        await _mediator.Send(customer);
        return NoContent();
    }

    // DELETE: api/<CustomersController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteCustomerCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
