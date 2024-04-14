using Domain.DTO_s.ChallengeDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/challenge")]
    public class ChallengeController(IChallengeService challengeService) : ControllerBase
    {
        [HttpGet]
        public async Task<Response<List<GetChallengeDTO>>> GetChallengeAsync()
        {
            return await challengeService.GetChallengesAsync();
        }

        [HttpGet("{challengeId:int}")] 
        public async Task<Response<GetChallengeDTO>> GetChallengeByIdAsync(int challengeId)
        {
            return await challengeService.GetChallengeByIdAsync(challengeId);
        }

        [HttpPost] 
        public async Task<Response<string>>AddChallengeAsync(AddChallengeDTO challengeDTO)
        {
            return await challengeService.AddChallengeAsync(challengeDTO);
        }

        [HttpPut] 
        public async Task<Response<string>>UpdateChallengeAync(UpdateChallengeDTO challengeDTO)
        {
            return await challengeService.UpdateChallengeAsync(challengeDTO);
        }

        [HttpDelete("{challengeId:int}")] 
        public async Task<Response<bool>> DeleteChallengeAsync(int challengeId)
        {
            return await challengeService.DeleteChallengeAsync(challengeId);
        }

    }
}
