namespace ProfileApi.Controllers.User.Requests;

public class UpdatePasswordRequest
{
    public required Guid UserId { get; init; }
    
    public required string Password { get; init; }
    
    public required string SessionToken { get; init; }
}