using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : Controller
{
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly RemoveCarCommandHandler _removeCarCommandHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

    public CarsController(CreateCarCommandHandler createCarCommandHandler,
        GetCarByIdQueryHandler getCarByIdQueryHandler,
        GetCarQueryHandler getCarQueryHandler,
        UpdateCarCommandHandler updateCarCommandHandler,
        RemoveCarCommandHandler removeCarCommandHandler,
        GetCarWithBrandQueryHandler getCarWithBrandQueryHandler
    )
    {
        _createCarCommandHandler = createCarCommandHandler;
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _getCarQueryHandler = getCarQueryHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _removeCarCommandHandler = removeCarCommandHandler;
        _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
    }

    [HttpGet]
    public async Task<ActionResult> CarList()
    {
        var values  = await _getCarQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(value);
        
    }

    [HttpPost]
    public async Task<ActionResult> CreateCar(CreateCarCommand command)
    {
         await _createCarCommandHandler.Handle(command);
        return Ok("Successfully created Car section");
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Successfully removed Car section");
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Successfully updated Car section");
    }

    [HttpGet("GetCarWithBrand")]
    public async Task<ActionResult> GetCarWithBrand()
    {
        var values = await _getCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }
}