using System.Collections.Concurrent;
using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;

namespace ProfileDal.Users;

/// <inheritdoc />
internal class SessionRepository : ISessionRepository
{
    private static readonly ConcurrentDictionary<Guid, SessionDal> Store = new();

    public async Task AddSession(SessionDal session)
    {
        if (session.Id == Guid.Empty)
        {
            session = session with { Id = Guid.NewGuid() };
        }

        foreach (var sessionId in Store
                     .Where(v => v.Value.UserId == session.UserId)
                     .Select(v => v.Key))
        {
            Store.Remove(sessionId, out _);
        }
        
        if (Store.TryAdd(session.Id, session))
            return;
        
        throw new Exception("Ошибка добавления сессии");
    }

    public async Task<SessionDal> GetSession(Guid userId)
    {
        return Store.First(v => v.Value.UserId == userId).Value;
    }
}