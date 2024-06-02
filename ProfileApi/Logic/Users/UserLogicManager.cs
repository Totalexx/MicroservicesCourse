using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileLogic.Users;

/// <inheritdoc />
internal class UserLogicManager : IUserLogicManager
{
    private readonly IUserRepository _userRepository;
    private readonly ISessionLogicManager _sessionManager;

    public UserLogicManager(IUserRepository userRepository, ISessionLogicManager sessionManager)
    {
        _userRepository = userRepository;
        _sessionManager = sessionManager;
    }

    public async Task<Guid> CreateUserAsync(UserLogic user)
    {
        return await _userRepository.CreateUserAsync(new UserDal
        {
            Name = user.Name,
            Phone = user.Phone,
            Password = user.Password,
            Role = new RoleDal
            {
                Name = user.Role.Name
            }
        });
    }

    public async Task<UserLogic> GetUserInfo(Guid userId)
    {
        var userDal = await _userRepository.GetUserAsync(userId);
        return new UserLogic
        {
            Name = userDal.Name,
            Phone = userDal.Phone,
            Password = userDal.Password,
            Role = new RoleLogic
            {
                Name = userDal.Role.Name
            }
        };
    }

    public async Task<bool> UpdatePassword(Guid userId, string password, SessionLogic session)
    {
        if (!await _sessionManager.CheckAuthorization(session)) 
            return false;
        
        await _userRepository.UpdatePasswordAsync(userId, password);
        return true;

    }

    public async Task<bool> DeleteUser(Guid userId, SessionLogic session)
    {
        if (!await _sessionManager.CheckAuthorization(session)) 
            return false;
        
        await _userRepository.DeleteUserAsync(userId);
        return true;
    }
}