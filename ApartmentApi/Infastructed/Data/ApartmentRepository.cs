using System.Collections.Concurrent;
using Domain.Entities;
using Domain.Interfaces;

namespace ProfileDal.Data;

public class ApartmentRepository : IApartmentRepository
{
    
    private readonly ConcurrentDictionary<Guid, Apartment> Store = new();
    private readonly IAddressRepository _addressRepository;

    public ApartmentRepository(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<Apartment> Get(Guid apartmentId)
    {
        return Store[apartmentId];
    }

    public async Task<List<Apartment>> GetAll()
    {
        return Store.Values.ToList();
    }

    public async Task<List<Apartment>> GetAll(City city, int minRoomsCount, double maxPrice)
    {
        return Store.Values
            .Where(a => a.Address.City == city 
                        && a.RoomsCount >= minRoomsCount
                        && a.PricePerDay <= maxPrice)
            .ToList();
    }

    public async Task<Guid> Save(Apartment apartment)
    {
        if (apartment.Id == default)
        {
            apartment = apartment with{ Id = new Guid()};
        }

        Store[apartment.Id] = apartment;
        
        var address = apartment.Address with { Apartment = apartment };
        await _addressRepository.Add(address);
        
        return apartment.Id;
    }

    public async Task<bool> Delete(Apartment apartment)
    {
        return Store.ContainsKey(apartment.Id) 
               && Store.TryRemove(apartment.Id, out _)
               && await _addressRepository.Remove(apartment.Address);
    }
}