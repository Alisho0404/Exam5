using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.ParticipantDTO;
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
    public class ParticipantService(DataContext context) : IParticipantService
    {
        public async Task<Response<string>> AddParticipantAsync(AddParticipantDTO participant)
        {
            try
            {
                var newParticipant = new Participant()
                {
                    FullName=participant.FullName,
                    Email=participant.Email,
                    Phone=participant.Phone,
                    Password=participant.Password,
                    CreatedAt=participant.CreatedAt,
                    GroupId=participant.GroupId,
                    LocationId=participant.LocationId
                };
                await context.Participants.AddAsync(newParticipant);

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

        public async Task<Response<bool>> DeleteParticipantAsync(int id)
        {
            try
            {
                var existing = await context.Participants.FindAsync(id);
                if (existing == null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");

                }

                context.Participants.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetParticipantDTO>> GetParticipantByIdAsync(int id)
        {
            try
            {
                var participant = await context.Participants.FirstOrDefaultAsync(x => x.Id == id);
                if (participant != null)
                {
                    var result = new GetParticipantDTO()
                    {
                        FullName = participant.FullName,
                        Email = participant.Email,
                        Phone = participant.Phone,
                        Password = participant.Password,
                        CreatedAt = participant.CreatedAt,
                        GroupId = participant.GroupId,
                        LocationId = participant.LocationId
                    };
                    return new Response<GetParticipantDTO>(result);
                }
                return new Response<GetParticipantDTO>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                return new Response<GetParticipantDTO>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetParticipantDTO>>> GetParticipantsAsync()
        {
            try
            {
                var participants = await context.Participants.Where(x => x.Id > 0).ToListAsync();
                var list = new List<GetParticipantDTO>();
                foreach (var participant in participants)
                {
                    var challange = new GetParticipantDTO()
                    {

                        FullName = participant.FullName,
                        Email = participant.Email,
                        Phone = participant.Phone,
                        Password = participant.Password,
                        CreatedAt = participant.CreatedAt,
                        GroupId = participant.GroupId,
                        LocationId = participant.LocationId

                    };
                    list.Add(challange);
                }
                return new Response<List<GetParticipantDTO>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetParticipantDTO>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateParticipantAsync(UpdateParticipantDTO participant)
        {
            try
            {
                var existing = await context.Participants.FirstOrDefaultAsync(x => x.Id == participant.Id);
                if (existing == null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");

                }
                existing.FullName= participant.FullName;
                existing.Email= participant.Email;
                existing.Phone= participant.Phone;
                existing.Password= participant.Password;
                existing.CreatedAt = participant.CreatedAt;
                existing.GroupId= participant.GroupId;
                existing.LocationId = participant.LocationId;
               

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
