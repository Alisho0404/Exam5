using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.ParticipantDTO;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IParticipantService
    {
        Task<Response<List<GetParticipantDTO>>> GetParticipantsAsync();
        Task<Response<GetParticipantDTO>> GetParticipantByIdAsync(int id);
        Task<Response<string>> AddParticipantAsync(AddParticipantDTO participant);
        Task<Response<string>> UpdateParticipantAsync(UpdateParticipantDTO participant);
        Task<Response<bool>> DeleteParticipantAsync(int id);
    }
}
