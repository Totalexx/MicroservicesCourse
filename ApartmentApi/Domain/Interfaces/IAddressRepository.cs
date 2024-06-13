using Domain.Entities;

namespace Domain.Interfaces;

public interface IAddressRepository
{ 
    Task<Guid> Add(Address address);
    Task<Address> Get(Guid addressId);
    Task<bool> Remove(Address address);
}