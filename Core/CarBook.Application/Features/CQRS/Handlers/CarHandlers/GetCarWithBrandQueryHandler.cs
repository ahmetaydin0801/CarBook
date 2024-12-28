using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarWithBrandQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {

        var values = await _repository.GetAllAsync();
        
        
        return values.Select(x =>
            new GetCarWithBrandQueryResult
            {
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                CarId = x.CarId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Kilometers = x.Kilometers,
                Luggage = x.Luggage,
                Model = x.Model,
                Seats = x.Seats,
                Transmission = x.Transmission,
            }
        ).ToList();
    }
}