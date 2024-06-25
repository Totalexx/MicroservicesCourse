using Domain.Entities;

namespace Services.Interfaces;

public interface IApartmentService
{
    Task<Apartment> GetAsync(Guid apartmentId);
    Task<List<Apartment>> GetAllAsync();
    Task<List<Apartment>> GetAllFilteredAsync(string city, int minRoomsCount, double maxPrice);
    Task SaveAsync(Apartment apartment, string accessToken);
    Task UpdatePriceAsync(Guid apartmentId, double price, string accessToken);
    Task DeleteAsync(Guid apartmentId, string accessToken);
}