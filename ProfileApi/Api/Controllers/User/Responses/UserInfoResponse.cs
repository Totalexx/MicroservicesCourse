namespace ProfileApi.Controllers.User.Responses;

public record UserInfoResponse
{
    public required string Name { get; init; }
    
    public required string Phone { get; init; }
    
    public required string Role { get; init; }
}