using MauiApp2.Models;

namespace MauiApp2.Services;

public class CarService
{
    public List<Car> GetCars()
    {
        return new List<Car> 
        {
            new Car { Id = 1, Make = "Toyota", Model = "Corolla", Vin = "30" },
            new Car { Id = 2, Make = "Honda", Model = "Civic", Vin = "45" },
            new Car { Id = 3, Make = "Ford", Model = "Mondeo", Vin = "67" }
        };
    }
}