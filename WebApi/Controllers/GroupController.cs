using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.GroupDTO;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController(IGroupService GroupService):ControllerBase
    {
        [HttpGet]
        public async Task<Response<List<GetGroupDTO>>> GetGroupAsync()
        {
            return await GroupService.GetGroupsAsync();
        }

        [HttpGet("{GroupId:int}")]
        public async Task<Response<GetGroupDTO>> GetGroupByIdAsync(int GroupId)
        {
            return await GroupService.GetGroupByIdAsync(GroupId);
        }

        [HttpPost]
        public async Task<Response<string>> AddGroupAsync(AddGroupDTO GroupDTO)
        {
            return await GroupService.AddGroupAsync(GroupDTO);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateGroupAync(UpdateGroupDTO GroupDTO)
        {
            return await GroupService.UpdateGroupAsync(GroupDTO);
        }

        [HttpDelete("{GroupId:int}")]
        public async Task<Response<bool>> DeleteGroupAsync(int GroupId)
        {
            return await GroupService.DeleteGroupAsync(GroupId);
        }
    }
}
