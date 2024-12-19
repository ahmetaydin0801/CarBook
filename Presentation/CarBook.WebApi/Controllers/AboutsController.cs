using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AboutsController : ControllerBase
{
    private readonly CreateAboutCommandHandler _createAboutCommandHandler;
    private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
    private readonly GetAboutQueryHandler _getAboutQueryHandler;
    private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
    private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

    public AboutsController(CreateAboutCommandHandler createAboutCommandHandler,
        GetAboutByIdQueryHandler getAboutByIdQueryHandler,
        GetAboutQueryHandler getAboutQueryHandler,
        UpdateAboutCommandHandler updateAboutCommandHandler,
        RemoveAboutCommandHandler removeAboutCommandHandler
    )
    {
        _createAboutCommandHandler = createAboutCommandHandler;
        _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        _getAboutQueryHandler = getAboutQueryHandler;
        _updateAboutCommandHandler = updateAboutCommandHandler;
        _removeAboutCommandHandler = removeAboutCommandHandler;
    }

    [HttpGet]
    public async Task<ActionResult> AboutList()
    {
        var values  = await _getAboutQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutById(int id)
    {
        var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(value);
        
    }

    [HttpPost]
    public async Task<ActionResult> CreateAbout(CreateAboutCommand command)
    {
         await _createAboutCommandHandler.Handle(command);
        return Ok("Successfully created About section");
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveAbout(int id)
    {
        await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok("Successfully removed About section");
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAbout(UpdateAboutCommand command)
    {
        await _updateAboutCommandHandler.Handle(command);
        return Ok("Successfully updated About section");
    }
} 