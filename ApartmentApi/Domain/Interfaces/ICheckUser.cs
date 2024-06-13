namespace Domain.Interfaces;

public interface ICheckUser
{
    Task CheckUserExistAsync(Guid userId);
    Task CheckUserHasPermissionAsync(Guid userId, string accessToken);
}