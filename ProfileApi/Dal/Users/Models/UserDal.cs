using ExampleCore.Dal.Base;

namespace ProfileDal.Users.Models;

public record UserDal : BaseEntityDal<Guid>
{
    public required string Name { get; init; }
    
    public required string Phone { get; init; }
    
    public required string Password { get; init; }
    public required RoleDal Role { get; init; }
}