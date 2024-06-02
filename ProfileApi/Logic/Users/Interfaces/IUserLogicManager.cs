using ProfileLogic.Users.Models;

namespace ProfileLogic.Users.Interfaces;

/// <summary>
/// Работа с пользователем
/// </summary>
public interface IUserLogicManager
{
    Task<Guid> CreateUserAsync(UserLogic user);
    Task<UserLogic> GetUserInfo(Guid userId);
    Task<bool> UpdatePassword(Guid userId, string password, SessionLogic session);
    Task<bool> DeleteUser(Guid userId, SessionLogic session);
}

