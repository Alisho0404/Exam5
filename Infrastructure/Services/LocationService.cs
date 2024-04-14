using Domain.DTO_s.ChallengeDTO;
using Domain.DTO_s.LocationDTO;
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
    public class LocationService(DataContext context) : ILocationService
    {
        public async Task<Response<string>> AddLocationAsync(AddLocationDTO location)
        {
            try
            {
                var newLocation = new Location()
                {
                    Name = location.Name,
                    Description = location.Description
                };
                await context.Locations.AddAsync(newLocation);

                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Succesfully created");
                }
                return new Response<string>("Failed to add");
            }
            catch (Exception e)
            {

                
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteLocationAsync(int id)
        {
            try
            {
                var existing = await context.Locations.FindAsync(id);
                if (existing == null)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");

                }

                context.Locations.Remove(existing);
                await context.SaveChangesAsync();
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetLocationDTO>> GetLocationByIdAsync(int id)
        {
            try
            {
                var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
                if (location != null)
                {
                    var result = new GetLocationDTO()
                    {
                        Id = location.Id,
                        Name = location.Name,
                        Description = location.Description
                    };
                    return new Response<GetLocationDTO>(result);
                }
                return new Response<GetLocationDTO>(HttpStatusCode.BadRequest, "Not found");
            }
            catch (Exception e)
            {

                return new Response<GetLocationDTO>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<List<GetLocationDTO>>> GetLocationsAsync()
        {
            try
            {
                var locations = await context.Locations.Where(x => x.Id > 0).ToListAsync();
                var list = new List<GetLocationDTO>();
                foreach (var item in locations)
                {
                    var location = new GetLocationDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,

                    };
                    list.Add(location);
                }
                return new Response<List<GetLocationDTO>>(list);
            }
            catch (Exception e)
            {

                return new Response<List<GetLocationDTO>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateLocationAsync(UpdateLocationDTO location)
        {
            try
            {
                var existing = await context.Locations.FirstOrDefaultAsync(x => x.Id == location.Id);
                if (existing == null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");

                }
                existing.Name = location.Name;
                existing.Description = location.Description;

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
