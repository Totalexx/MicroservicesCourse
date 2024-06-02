namespace ProfileApi.Controllers.User.Requests;

public class DeleteUserRequest
{
    public required Guid UserId { get; init; }
    
    public required string SessionToken { get; init; }
}