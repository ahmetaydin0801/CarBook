using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            BigImageUrl = command.BigImageUrl,
            Luggage = command.Luggage,
            Kilometers = command.Kilometers,
            Model = command.Model,
            Seats = command.Seats,
            Transmission = command.Transmission,
            CoverImageUrl = command.CoverImageUrl,
            BrandId = command.BrandId,
            Fuel = command.Fuel,
        });
    }
}