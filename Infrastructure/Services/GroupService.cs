using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.GroupDTO;
using Domain.Enteties;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GroupService(DataContext context) : IGroupService
    {
        public async Task<Response<string>> AddGroupAsync(AddGroupDTO group)
        {
            try
            {
                var newGroup = new Group()
                {
                    GroupNick=group.GroupNick,
                    CreatedAt=group.CreatedAt,
                    NeededMember=group.NeededMember,
                    TeamSlogan=group.TeamSlogan,
                    ChallengeId=group.ChallengeId
                };
                await context.Groups.AddAsync(newGroup);

                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Succesfully created");
                }
                return new Response<string>("Failed to add");
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        public async Task<Response<bool>> DeleteGroupAsync(int id)
        {
            try
            {
                var existing = await context.Groups.FindAsync(id);
                if (existing == null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");

                }

                context.Groups.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetGroupDTO>> GetGroupByIdAsync(int id)
        {
            try
            {
                var group = await context.Groups.FirstOrDefaultAsync(x => x.Id == id);
                if (group != null)
                {
                    var result = new GetGroupDTO()
                    {  
                       Id=group.Id,                      
                       GroupNick=group.GroupNick, 
                       ChallengeId=group.ChallengeId, 
                       NeededMember=group.NeededMember,
                       TeamSlogan = group.TeamSlogan, 
                       CreatedAt=group.CreatedAt

                    };
                    return new Response<GetGroupDTO>(result);
                }
                return new Response<GetGroupDTO>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                return new Response<GetGroupDTO>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetGroupDTO>>> GetGroupsAsync()
        {
            try
            {
                var group = await context.Groups.Where(x => x.Id > 0).ToListAsync();
                var list = new List<GetGroupDTO>();
                foreach (var item in group)
                {
                    var challange = new GetGroupDTO()
                    {
                        Id = item.Id,
                        GroupNick = item.GroupNick,
                        ChallengeId = item.ChallengeId,
                        NeededMember = item.NeededMember,
                        TeamSlogan = item.TeamSlogan,
                        CreatedAt = item.CreatedAt
                    };
                    list.Add(challange);
                }
                return new Response<List<GetGroupDTO>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetGroupDTO>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDTO group)
        {
            try
            {
                var existing = await context.Groups.FirstOrDefaultAsync(x => x.Id == group.Id);
                if (existing == null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");

                }
                existing.GroupNick = group.GroupNick;
                existing.ChallengeId = group.ChallengeId;
                existing.NeededMember = group.NeededMember;
                existing.TeamSlogan = group.TeamSlogan;
                existing.CreatedAt = group.CreatedAt;

                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return new Response<string>("Succesfully updated");
                }
                return new Response<string>("Failed to update");
            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
