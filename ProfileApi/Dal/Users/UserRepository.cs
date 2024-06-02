using System.Collections.Concurrent;
using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;

namespace ProfileDal.Users;

/// <inheritdoc />
internal class UserRepository : IUserRepository
{
    private static readonly ConcurrentDictionary<Guid, UserDal> Store = new();
    
    public async Task<UserDal> GetUserAsync(Guid userId)
    {
        if (Store.TryGetValue(userId, out var user))
        {
            return user;
        }

        throw new Exception("Пользователь не найден");
    }

    public async Task<UserDal> GetUserAsync(string phone, string password)
    {
        try
        {
            return Store.First(v => v.Value.Password == password && v.Value.Phone == phone).Value;
        }
        catch (InvalidOperationException e)
        {
            throw new Exception("Пользователь не найден");
        }
    }

    public async Task<Guid> CreateUserAsync(UserDal user)
    {
        if (user.Id == Guid.Empty)
        {
            user = user with { Id = Guid.NewGuid() };
        }
        
        if (Store.TryAdd(user.Id, user))
        {
            return user.Id;
        }
        
        throw new Exception("Ошибка добавления пользователя");
    }

    public async Task UpdatePasswordAsync(Guid userId, string password)
    {
        if (Store.TryGetValue(userId, out var user))
        {
            user = user with { Password = password };
            Store[userId] = user;
            return;
        }

        throw new Exception("Пользователь не найден");
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        if (Store.TryRemove(userId, out _))
            return;

        throw new Exception("Пользователь не найден");
    }
}