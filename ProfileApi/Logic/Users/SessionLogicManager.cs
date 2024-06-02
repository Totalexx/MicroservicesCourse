using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileLogic.Users;

internal class SessionLogicManager : ISessionLogicManager
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IUserRepository _userRepository;

    public SessionLogicManager(ISessionRepository sessionRepository, IUserRepository userRepository)
    {
        _sessionRepository = sessionRepository;
        _userRepository = userRepository;
    }

    public async Task<SessionLogic> Authorize(string phone, string password)
    {
        var userDal = await _userRepository.GetUserAsync(phone, password);
        var sessionToken = new Guid().ToString();
        await _sessionRepository.AddSession(new SessionDal
        {
            UserId = userDal.Id,
            SessionToken = sessionToken
        });

        return new SessionLogic
        {
            UserId = userDal.Id,
            SessionToken = sessionToken
        };
    }

    public async Task<bool> CheckAuthorization(SessionLogic session)
    {
        var sessionDal = await _sessionRepository.GetSession(session.UserId);
        return sessionDal.SessionToken == session.SessionToken;
    }
}