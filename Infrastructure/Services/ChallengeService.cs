using Domain.DTO_s.ChallengeDTO;
using Domain.Enteties;
using Domain.Responses;
using Infrastructure.Data;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ChallengeService(DataContext context) : IChallengeService
    {
        public async Task<Response<string>> AddChallengeAsync(AddChallengeDTO challenge)
        {
            try
            {
                var newChallenge = new Challenge()
                {
                    Description = challenge.Description,
                    Title = challenge.Title
                };
                await context.Challenges.AddAsync(newChallenge);

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

        public async Task<Response<bool>> DeleteChallengeAsync(int id)
        {
            try
            {
                var existing = await context.Challenges.FindAsync(id);
                if (existing == null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");

                } 

                context.Challenges.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetChallengeDTO>> GetChallengeByIdAsync(int id)
        {
            try
            {
                var challenge = await context.Challenges.FirstOrDefaultAsync(x => x.Id == id);
                if (challenge != null)
                {
                    var result = new GetChallengeDTO()
                    {
                        Id = challenge.Id,
                        Title = challenge.Title,
                        Description = challenge.Description
                    };
                    return new Response<GetChallengeDTO>(result);
                }
                return new Response<GetChallengeDTO>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                return new Response<GetChallengeDTO>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetChallengeDTO>>> GetChallengesAsync()
        {
            try
            {
                var challenges = await context.Challenges.Where(x => x.Id > 0).ToListAsync();
                var list = new List<GetChallengeDTO>();
                foreach (var item in challenges)
                {
                    var challange = new GetChallengeDTO()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,

                    };
                    list.Add(challange);
                }
                return new Response<List<GetChallengeDTO>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetChallengeDTO>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateChallengeAsync(UpdateChallengeDTO challenge)
        {
            try
            {
                var existing = await context.Challenges.FirstOrDefaultAsync(x => x.Id == challenge.Id);
                if (existing == null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");

                }
                existing.Title = challenge.Title;
                existing.Description = challenge.Description;

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
