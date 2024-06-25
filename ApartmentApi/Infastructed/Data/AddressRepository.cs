using System.Collections.Concurrent;
using Domain.Entities;
using Domain.Interfaces;

namespace ProfileDal.Data;

public class AddressRepository : IAddressRepository
{
    private readonly ConcurrentDictionary<Guid, Address> Store = new();

    public async Task<Guid> Add(Address address)
    {
        if (address.Id == default)
        {
            address = address with { Id = new Guid() };
        }

        Store[address.Id] = address;
        return address.Id;
    }

    public async Task<Address> Get(Guid addressId)
    {
        return Store[addressId];
    }

    public async Task<bool> Remove(Address address)
    {
        return Store.TryRemove(address.Id, out _);
    }
}