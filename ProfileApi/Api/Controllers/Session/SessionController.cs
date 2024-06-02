using Microsoft.AspNetCore.Mvc;
using ProfileApi.Controllers.User.Requests;
using ProfileApi.Controllers.User.Responses;
using ProfileLogic.Users.Interfaces;

namespace ProfileApi.Controllers.Session;

[Route("public/user")]
public class SessionController : ControllerBase
{
    private readonly ISessionLogicManager _sessionLogicManager;

    public SessionController(ISessionLogicManager sessionLogicManager)
    {
        _sessionLogicManager = sessionLogicManager;
    }
    
    [HttpPost]
    [ProducesResponseType<AuthorizeResponse>(200)]
    public async Task<IActionResult> AuthorizeAsync([FromBody] AuthorizeRequest request)
    {
        var session = await _sessionLogicManager.Authorize(request.Phone, request.Password);
        return Ok(new AuthorizeResponse
        {
            UserId = session.UserId,
            SessionToken = session.SessionToken
        });
    }
}