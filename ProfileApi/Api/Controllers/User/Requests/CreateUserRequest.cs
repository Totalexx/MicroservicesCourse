namespace ProfileApi.Controllers.User.Requests;

public record CreateUserRequest
{
    public required string Name { get; init; }
    
    public required string Phone { get; init; }
    
    public required string Password { get; init; }
    public required string Role { get; init; }
}