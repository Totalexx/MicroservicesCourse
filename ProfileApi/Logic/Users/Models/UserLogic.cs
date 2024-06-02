namespace ProfileLogic.Users.Models;

/// <summary>
/// Модель пользователя для слоя Logic 
/// </summary>
public class UserLogic
{
    public required string Name { get; init; }
    
    public required string Phone { get; init; }
    
    public required string Password { get; init; }
    public required RoleLogic Role { get; init; }
}