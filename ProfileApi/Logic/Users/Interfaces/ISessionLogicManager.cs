using ProfileLogic.Users.Models;

namespace ProfileLogic.Users.Interfaces;

public interface ISessionLogicManager
{
    Task<SessionLogic> Authorize(string phone, string password);
    Task<bool> CheckAuthorization(SessionLogic session);
}