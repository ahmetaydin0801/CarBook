using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetCarByIdQueryResult> Handle(
        GetCarByIdQuery query
    )
    {

        var values = await _repository.GetByIdAsync(query.Id);


        return
            new GetCarByIdQueryResult
            {
                BrandId = values.BrandId,
                BigImageUrl = values.BigImageUrl,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                CarId = values.CarId,
                Transmission = values.Transmission,
                Seats = values.Seats,
                Model = values.Model,
                Kilometers = values.Kilometers,
                Luggage = values.Luggage,
            };
    }
}