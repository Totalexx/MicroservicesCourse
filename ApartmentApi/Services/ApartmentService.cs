using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ICheckUser _checkUser;

    public ApartmentService(IApartmentRepository apartmentRepository, ICheckUser checkUser, ICityRepository cityRepository)
    {
        _apartmentRepository = apartmentRepository;
        _checkUser = checkUser;
        _cityRepository = cityRepository;
    }

    public async Task<Apartment> GetAsync(Guid apartmentId)
    {
        return await _apartmentRepository.Get(apartmentId);
    }

    public async Task<List<Apartment>> GetAllAsync()
    {
        return await _apartmentRepository.GetAll();
    }

    public async Task<List<Apartment>> GetAllFilteredAsync(string city, int minRoomsCount, double maxPrice)
    {
        var cityModel = await _cityRepository.Get(city);
        return await _apartmentRepository.GetAll(cityModel, minRoomsCount, maxPrice);
    }

    public async Task SaveAsync(Apartment apartment, string accessToken)
    {
        await _checkUser.CheckUserExistAsync(apartment.OwnerId);
        await _checkUser.CheckUserHasPermissionAsync(apartment.OwnerId, accessToken);
        await _apartmentRepository.Save(apartment);
    }

    public async Task UpdatePriceAsync(Guid apartmentId, double price, string accessToken)
    {
        var apartment = await _apartmentRepository.Get(apartmentId);
        await _checkUser.CheckUserHasPermissionAsync(apartment.OwnerId, accessToken);
        apartment = apartment with { PricePerDay = price };
        await _apartmentRepository.Save(apartment);
    }

    public async Task DeleteAsync(Guid apartmentId, string accessToken)
    {
        var apartment = await _apartmentRepository.Get(apartmentId);
        await _checkUser.CheckUserHasPermissionAsync(apartment.OwnerId, accessToken);
        await _apartmentRepository.Delete(apartment);
    }
}