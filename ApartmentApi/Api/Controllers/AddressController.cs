using Api.Controllers.Requests;
using Api.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("public/address")]
public class AddressController : ControllerBase
{
    private readonly ICityService _cityService;

    public AddressController(ICityService cityService)
    {
        _cityService = cityService;
    }
    
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult> AddCityAsync([FromBody] AddCityRequest request)
    {
        await _cityService.GetByNameAsync(request.CityName);
        return Ok();
    } 
    
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult> GetAllCitiesAsync()
    {
        var cities = await _cityService.GetAll();
        return Ok(new CitiesResponse
        {
            Cities = cities.Select(c => c.Name).ToList()
        });
    }
}
