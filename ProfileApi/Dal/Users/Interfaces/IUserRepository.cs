using ProfileDal.Users.Models;

namespace ProfileDal.Users.Interfaces;

public interface IUserRepository
{
    Task<UserDal> GetUserAsync(Guid userId);

    Task<UserDal> GetUserAsync(string phone, string password);
    
    Task<Guid> CreateUserAsync(UserDal user);

    Task UpdatePasswordAsync(Guid userId, string password);
    
    Task DeleteUserAsync(Guid userId);
}


