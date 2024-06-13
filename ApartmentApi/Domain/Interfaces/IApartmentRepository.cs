using Domain.Entities;

namespace Domain.Interfaces;

public interface IApartmentRepository
{
    Task<Apartment> Get(Guid apartmentId);
    Task<List<Apartment>> GetAll();
    Task<List<Apartment>> GetAll(City city, int minRoomsCount, double maxPrice);
    Task<Guid> Save(Apartment apartment);
    Task<bool> Delete(Apartment apartment);
}