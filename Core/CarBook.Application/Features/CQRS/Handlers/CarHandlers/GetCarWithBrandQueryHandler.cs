using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;


namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarWithBrandQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public List<GetCarWithBrandQueryResult> Handle()
    {

        var values =  _repository.GetCarsListWithBrands();
        
        
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