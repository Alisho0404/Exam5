using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.LocationDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController(ILocationService LocationService):ControllerBase
    {
        [HttpGet]
        public async Task<Response<List<GetLocationDTO>>> GetLocationAsync()
        {
            return await LocationService.GetLocationsAsync();
        }

        [HttpGet("{LocationId:int}")]
        public async Task<Response<GetLocationDTO>> GetLocationByIdAsync(int LocationId)
        {
            return await LocationService.GetLocationByIdAsync(LocationId);
        }

        [HttpPost]
        public async Task<Response<string>> AddLocationAsync(AddLocationDTO LocationDTO)
        {
            return await LocationService.AddLocationAsync(LocationDTO);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateLocationAync(UpdateLocationDTO LocationDTO)
        {
            return await LocationService.UpdateLocationAsync(LocationDTO);
        }

        [HttpDelete("{LocationId:int}")]
        public async Task<Response<bool>> DeleteLocationAsync(int LocationId)
        {
            return await LocationService.DeleteLocationAsync(LocationId);
        }
    }
}
