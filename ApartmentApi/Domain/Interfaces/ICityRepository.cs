using Domain.Entities;

namespace Domain.Interfaces;

public interface ICityRepository
{ 
    Task<Guid> Add(City city);
    Task<City> Get(Guid cityId);
    Task<City> Get(string name);
    Task<List<City>> GetAll();
}