using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.LocationDTO;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ILocationService
    {
        Task<Response<List<GetLocationDTO>>> GetLocationsAsync();
        Task<Response<GetLocationDTO>> GetLocationByIdAsync(int id);
        Task<Response<string>> AddLocationAsync(AddLocationDTO location);
        Task<Response<string>> UpdateLocationAsync(UpdateLocationDTO location);
        Task<Response<bool>> DeleteLocationAsync(int id);
    }
}
