using ArtisanGemstoneIMS.Application.Products.Commands;
using ArtisanGemstoneIMS.Application.Products.Queries;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtisanGemstoneIMS.WebUI.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<ProductsController>
    [HttpGet]
    public async Task<ActionResult<List<ProductsListDto>>> GetAll()
    {
        var products = await _mediator.Send(new GetProductsListQuery());
        return Ok(products);
    }

    // GET: api/<ProductsController>/unarchived
    [HttpGet("unarchived")]
    public async Task<ActionResult<List<ProductsListDto>>> GetUnarchived()
    {
        var products = await _mediator.Send(new GetUnarchivedProductsListQuery());
        return Ok(products);
    }

    // GET: api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsDto>> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductDetailsQuery { Id = id });
        return Ok(product);
    }

    // POST: api/<ProductsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Create(CreateProductCommand product)
    {
        var response = await _mediator.Send(product);
        return CreatedAtAction(nameof(GetAll), new { id = response });
    }

    // PUT: api/<ProductsController>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(UpdateProductCommand product)
    {
        await _mediator.Send(product);
        return NoContent();
    }

    // PATCH: api/<ProductsController>/5
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Archive(Guid id)
    {
        var command = new ArchiveProductCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
