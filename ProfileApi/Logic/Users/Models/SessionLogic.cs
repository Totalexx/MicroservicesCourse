namespace ProfileLogic.Users.Models;

public record SessionLogic
{
    public required Guid UserId { get; init; }
    
    public required string SessionToken { get; init; }
};