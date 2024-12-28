using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : Controller
{
  private readonly CreateBrandCommandHandler _createBrandCommandHandler;
    private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
    private readonly GetBrandQueryHandler _getBrandQueryHandler;
    private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
    private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

    public BrandsController(CreateBrandCommandHandler createBrandCommandHandler,
        GetBrandByIdQueryHandler getBrandByIdQueryHandler,
        GetBrandQueryHandler getBrandQueryHandler,
        UpdateBrandCommandHandler updateBrandCommandHandler,
        RemoveBrandCommandHandler removeBrandCommandHandler
    )
    {
        _createBrandCommandHandler = createBrandCommandHandler;
        _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        _getBrandQueryHandler = getBrandQueryHandler;
        _updateBrandCommandHandler = updateBrandCommandHandler;
        _removeBrandCommandHandler = removeBrandCommandHandler;
    }

    [HttpGet]
    public async Task<ActionResult> BrandList()
    {
        var values  = await _getBrandQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(int id)
    {
        var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
        return Ok(value);
        
    }

    [HttpPost]
    public async Task<ActionResult> CreateBrand(CreateBrandCommand command)
    {
         await _createBrandCommandHandler.Handle(command);
        return Ok("Successfully created Brand section");
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBrand(int id)
    {
        await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
        return Ok("Successfully removed Brand section");
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBrand(UpdateBrandCommand command)
    {
        await _updateBrandCommandHandler.Handle(command);
        return Ok("Successfully updated Brand section");
    }
}