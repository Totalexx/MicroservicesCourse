using Microsoft.AspNetCore.Mvc;
using ProfileApi.Controllers.Rating.Requests;
using ProfileApi.Controllers.Rating.Responses;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileApi.Controllers.Rating;

[Route("public/rating")]
public class RatingController : ControllerBase
{
    private readonly IRatingLogicManager _ratingLogicManager;

    public RatingController(IRatingLogicManager userLogicManager)
    {
        _ratingLogicManager = userLogicManager;
    }
    
    [HttpPost]
    [ProducesResponseType<RatingResponse>(200)]
    public async Task<IActionResult> AddRatingAsync([FromBody] AddRatingRequest request)
    {
        await _ratingLogicManager.AddRating(new RatingLogic
        {
            User = request.User,
            Rater = request.Rater,
            Rating = request.Rating
        });
        return Ok();
    }
    
    [HttpGet]
    [ProducesResponseType<RatingResponse>(200)]
    public async Task<IActionResult> GetAverageRatingAsync([FromQuery] Guid userId)
    {
        var rating = await _ratingLogicManager.GetAverageRating(userId);
        return Ok(new RatingResponse
        {
            User = userId,
            Rating = rating
        });
    }
}