using Api.Controllers.Requests;
using Api.Controllers.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("public/apartment")]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;
    private readonly ICityService _cityService;

    public ApartmentController(IApartmentService apartmentService, ICityService cityService)
    {
        _apartmentService = apartmentService;
        _cityService = cityService;
    }

    [HttpGet]
    [ProducesResponseType<ApartmentInfoResponse>(200)]
    public async Task<ActionResult> GetApartmentInfoAsync([FromBody] ApartmentInfoRequest request)
    {
        var apartment = await _apartmentService.GetAsync(request.ApartmentId);
        return Ok(ApartmentToResponse(apartment));
    }

    [HttpGet]
    [Route("all")]
    [ProducesResponseType<AllApartmentsInfoResponse>(200)]
    public async Task<ActionResult> GetAllApartmentsInfoAsync()
    {
        var apartments = await _apartmentService.GetAllAsync();

        var apartmentDtos = apartments.Select(ApartmentToResponse).ToList();
        
        return Ok(new AllApartmentsInfoResponse
        {
            Apartments = apartmentDtos
        });
    }

    [HttpGet]
    [Route("all/filtered")]
    [ProducesResponseType<AllApartmentsInfoResponse>(200)]
    public async Task<ActionResult> GetAllApartmentsInfoByFilterAsync([FromBody] FilteredApartmentsInfoRequest request)
    {
        var apartments = await _apartmentService.GetAllFilteredAsync(request.City, request.MinRoomsCount, request.MaxPricePerDay);

        var apartmentDtos = apartments.Select(ApartmentToResponse).ToList();
        
        return Ok(new AllApartmentsInfoResponse
        {
            Apartments = apartmentDtos
        });
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult> AddApartmentAsync([FromBody] AddApartmentRequest request)
    {
        var city = await _cityService.GetByNameAsync(request.City);
        await _apartmentService.SaveAsync(new Apartment
        {
            Address = new Address
            {
                Apartment = default,
                City = city,
                Street = request.Street,
                BuildingNumber = request.BuildingNumber,
                ApartmentNumber = request.ApartmentNumber
            },
            RoomsCount = request.RoomsCount,
            PricePerDay = request.PricePerDay,
            OwnerId = request.OwnerId
        }, request.AccessToken);

        return Ok();
    }

    [HttpPut]
    [ProducesResponseType(200)]
    public async Task<ActionResult> UpdateApartmentPriceAsync([FromBody] UpdateApartmentPriceRequest request)
    {
        await _apartmentService.UpdatePriceAsync(request.ApartmentId, request.PricePerDay, request.AccessToken);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(200)]
    public async Task<ActionResult> RemoveApartmentAsync([FromBody] RemoveApartmentRequest request)
    {
        await _apartmentService.DeleteAsync(request.ApartmentId, request.AccessToken);
        return Ok();
    }

    private static ApartmentInfoResponse ApartmentToResponse(Apartment apartment)
    {
        return new ApartmentInfoResponse
        {
            City = apartment.Address.City.Name,
            Street = apartment.Address.Street,
            BuildingNumber = apartment.Address.BuildingNumber,
            ApartmentNumber = apartment.Address.ApartmentNumber,
            RoomsCount = apartment.RoomsCount,
            PricePerDay = apartment.PricePerDay,
            OwnerId = apartment.OwnerId
        };
    }
}
