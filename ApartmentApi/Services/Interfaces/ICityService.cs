using Domain.Entities;

namespace Services.Interfaces;

public interface ICityService
{
    Task AddAsync(City city);
    Task<City> GetByNameAsync(string cityName);
    Task<List<City>> GetAll();
}