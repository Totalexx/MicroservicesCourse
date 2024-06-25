using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task AddAsync(City city)
    {
        await _cityRepository.Add(city);
    }

    public async Task<City> GetByNameAsync(string cityName)
    {
        return await _cityRepository.Get(cityName);
    }

    public async Task<List<City>> GetAll()
    {
        return await _cityRepository.GetAll();
    }
}