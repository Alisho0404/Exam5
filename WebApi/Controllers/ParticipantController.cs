using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.ParticipantDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/participant")]
    public class ParticipantController(IParticipantService ParticipantService) : ControllerBase
    {
        [HttpGet]
        public async Task<Response<List<GetParticipantDTO>>> GetParticipantAsync()
        {
            return await ParticipantService.GetParticipantsAsync();
        }

        [HttpGet("{ParticipantId:int}")]
        public async Task<Response<GetParticipantDTO>> GetParticipantByIdAsync(int ParticipantId)
        {
            return await ParticipantService.GetParticipantByIdAsync(ParticipantId);
        }

        [HttpPost]
        public async Task<Response<string>> AddParticipantAsync(AddParticipantDTO ParticipantDTO)
        {
            return await ParticipantService.AddParticipantAsync(ParticipantDTO);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateParticipantAync(UpdateParticipantDTO ParticipantDTO)
        {
            return await ParticipantService.UpdateParticipantAsync(ParticipantDTO);
        }

        [HttpDelete("{ParticipantId:int}")]
        public async Task<Response<bool>> DeleteParticipantAsync(int ParticipantId)
        {
            return await ParticipantService.DeleteParticipantAsync(ParticipantId);
        }
    }
}
