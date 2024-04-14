using Domain.DTO_s.ChallengeDTO;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IChallengeService
    { 
        Task<Response<List<GetChallengeDTO>>> GetChallengesAsync();
        Task<Response<GetChallengeDTO>> GetChallengeByIdAsync(int id);
        Task<Response<string>> AddChallengeAsync(AddChallengeDTO challenge);
        Task<Response<string>> UpdateChallengeAsync(UpdateChallengeDTO challenge);
        Task<Response<bool>> DeleteChallengeAsync(int id);
    }
}
