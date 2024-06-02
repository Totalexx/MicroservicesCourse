using ProfileDal.Users.Models;

namespace ProfileDal.Users.Interfaces;

public interface ISessionRepository 
{
    Task AddSession(SessionDal session);
    Task<SessionDal> GetSession(Guid userId);
}