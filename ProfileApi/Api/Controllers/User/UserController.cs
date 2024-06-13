using Microsoft.AspNetCore.Mvc;
using ProfileApi.Controllers.User.Requests;
using ProfileApi.Controllers.User.Responses;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileApi.Controllers.User;

[Route("public/user")]
public class UserController : ControllerBase
{
    private readonly IUserLogicManager _userLogicManager;

    public UserController(IUserLogicManager userLogicManager)
    {
        _userLogicManager = userLogicManager;
    }
    
    [HttpPost]
    [ProducesResponseType<Guid>(200)]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        var id = await _userLogicManager.CreateUserAsync(new UserLogic
        {
            Name = request.Name,
            Phone = request.Phone,
            Password = request.Password,
            Role = new RoleLogic
            {
                Name = request.Role
            }
        });
        
        return Ok(id);
    }
    
    [HttpGet]
    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<IActionResult> GetUserInfoAsync([FromQuery] Guid userId)
    {
        var userInfo = await _userLogicManager.GetUserInfo(userId);
        return Ok(new UserInfoResponse
        {
            Name = userInfo.Name,
            Phone = userInfo.Phone,
            Role = userInfo.Role.Name
        });
    }
    
    [HttpPut]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordRequest request)
    {
        var isSuccessful = await _userLogicManager.UpdatePassword(request.UserId, request.Password, new SessionLogic
        {
            UserId = request.UserId,
            SessionToken = request.SessionToken
        });

        return isSuccessful ? Ok() : Forbid();
    }
    
    [HttpDelete]
    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<IActionResult> DeleteUserAsync([FromBody] DeleteUserRequest request)
    {
        var isSuccessful = await _userLogicManager.DeleteUser(request.UserId, new SessionLogic
        {
            UserId = request.UserId,
            SessionToken = request.SessionToken
        });

        return isSuccessful ? Ok() : Forbid();
    }
}