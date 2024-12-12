// Car.cs
namespace CarBook.Domain.Entities;

public class Car
{
    public int CarId { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public int Kilometers { get; set; }
    public string Transmission { get; set; }
    public byte Seats { get; set; }
    public byte Luggage { get; set; }
    public string Fuel { get; set; }
    public string BigImageUrl { get; set; }
    
}