using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Functions
{
    public class SearchOffersFunction
    {
        private readonly RefugeesDbContext _dbContext;

        public SearchOffersFunction(RefugeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("SearchOffers")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] SearchOffersRequest request)
        {
            var result = new SearchOffersResult();

            if (request.Shelter.IsNeeded)
            {
                var periodInDays = request.Shelter.Period.InDays();
                var shelterQuery = _dbContext.Set<Shelter>()
                    .Where(s => s.AdultCapacity >= request.NumberOfAdults)
                    .Where(s => s.ChildrenCapacity >= request.NumberOfChildren)
                    .Where(s => s.MaxPeriodInDays >= periodInDays)
                    .AsQueryable();
                
                if (request.Shelter.AllowsPets)
                {
                    shelterQuery = shelterQuery.Where(s => s.AllowsPets);
                }

                if (request.Address?.Region is not null)
                {
                    shelterQuery = shelterQuery.Where(s => s.Address.RegionId == request.Address.Region.Id);
                }

                if (request.Address?.City is not null)
                {
                    shelterQuery = shelterQuery.Where(s => s.Address.CityId == request.Address.City.Id);
                }

                result.ShelterResults = await shelterQuery
                    .Select(s => new SearchOffersResult.ShelterResult
                    {
                        Id = s.Id,
                        Name = s.ContactPerson.Name,
                        Phone = s.ContactPerson.Phone,
                        AdultCapacity = s.AdultCapacity,
                        ChildrenCapacity = s.ChildrenCapacity,
                        Address = new AddressModel
                        {
                            Region = new RegionModel(s.Address.Region.Id, s.Address.Region.Name),
                            City = new CityModel(s.Address.City.Id, s.Address.City.Name),
                        },
                    })
                    .Take(5)
                    .ToListAsync();
            }

            if (request.Transport.IsNeeded)
            {
                var now = DateTime.Now;
                var transportQuery = _dbContext.Set<Transport>()
                    .Where(t => !t.ExpiresOn.HasValue || t.ExpiresOn > now)
                    .Where(t => t.AdultSeats >= request.NumberOfAdults)
                    .Where(t => t.ChildSeats >= request.NumberOfChildren)
                    .Where(t => t.StartingPoint == request.StartingPoint)
                    .AsQueryable();

                if (request.Address?.Region is not null)
                {
                    transportQuery = transportQuery.Where(s => s.Destination.RegionId == request.Address.Region.Id);
                }

                if (request.Address?.City is not null)
                {
                    transportQuery = transportQuery.Where(s => s.Destination.CityId == request.Address.City.Id);
                }

                result.TransportResults = await transportQuery
                    .Select(t => new SearchOffersResult.TransportResult
                    {
                        Id = t.Id,
                        Name = t.ContactPerson.Name,
                        Phone = t.ContactPerson.Phone,
                        AdultSeats = t.AdultSeats,
                        ChildSeats = t.ChildSeats,
                        Destination = new AddressModel
                        {
                            Region = new RegionModel(t.Destination.Region.Id, t.Destination.Region.Name),
                            City = new CityModel(t.Destination.City.Id, t.Destination.City.Name),
                        },
                        LeavesAt = t.ExpiresOn,
                    })
                    .Take(5)
                    .ToListAsync();
            }

            return new OkObjectResult(result);
        }
    }
}
