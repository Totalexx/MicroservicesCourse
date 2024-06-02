namespace ProfileApi.Controllers.User.Requests;

public record AuthorizeRequest
{
    public required string Phone { get; init; }
    
    public required string Password { get; init; }
}