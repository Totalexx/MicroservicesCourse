using Domain.Entities;

namespace Domain.Interfaces;

public interface IStoreAddress
{ 
    Task<Guid> Add(Address apartment);
}