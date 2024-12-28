using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactsController : Controller
{
      private readonly CreateContactCommandHandler _createContactCommandHandler;
    private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
    private readonly GetContactQueryHandler _getContactQueryHandler;
    private readonly UpdateContactCommandHandler _updateContactCommandHandler;
    private readonly RemoveContactCommandHandler _removeContactCommandHandler;


    public ContactsController(CreateContactCommandHandler createContactCommandHandler,
        GetContactByIdQueryHandler getContactByIdQueryHandler,
        GetContactQueryHandler getContactQueryHandler,
        UpdateContactCommandHandler updateContactCommandHandler,
        RemoveContactCommandHandler removeContactCommandHandler
    )
    {
        _createContactCommandHandler = createContactCommandHandler;
        _getContactByIdQueryHandler = getContactByIdQueryHandler;
        _getContactQueryHandler = getContactQueryHandler;
        _updateContactCommandHandler = updateContactCommandHandler;
        _removeContactCommandHandler = removeContactCommandHandler;

    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var values  = await _getContactQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
        return Ok(value);
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand command)
    {
         await _createContactCommandHandler.Handle(command);
        return Ok("Successfully created Contact section");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveContact(int id)
    {
        await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
        return Ok("Successfully removed Contact section");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
    {
        await _updateContactCommandHandler.Handle(command);
        return Ok("Successfully updated Contact section");
    }

}