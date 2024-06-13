using System.Collections.Concurrent;
using Domain.Entities;
using Domain.Interfaces;

namespace ProfileDal.Data;

public class CityRepository : ICityRepository
{
    private readonly ConcurrentDictionary<Guid, City> Store = new();
    
    public async Task<Guid> Add(City city)
    {
        if (Store.Values.Any(c => c.Name == city.Name))
            throw new ArgumentException("Город с таким названием уже есть");

        if (city.Id == default)
        {
            city = city with { Id = new Guid() };
        }

        Store[city.Id] = city;
        
        return city.Id;
    }

    public async Task<City> Get(Guid cityId)
    {
        return Store[cityId];
    }

    public async Task<City> Get(string name)
    {
        return Store.Values.First(c => c.Name == name);
    }

    public async Task<List<City>> GetAll()
    {
        return Store.Values.ToList();
    }
}