using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.GroupDTO;
using Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IGroupService
    {
        Task<Response<List<GetGroupDTO>>> GetGroupsAsync();
        Task<Response<GetGroupDTO>> GetGroupByIdAsync(int id);
        Task<Response<string>> AddGroupAsync(AddGroupDTO group);
        Task<Response<string>> UpdateGroupAsync(UpdateGroupDTO group);
        Task<Response<bool>> DeleteGroupAsync(int id);
    }
}
