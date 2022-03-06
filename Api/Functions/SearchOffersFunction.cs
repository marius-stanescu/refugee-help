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
                    .Where(s => s.IsActive)
                    .Where(s => s.AdultCapacity >= request.NumberOfAdults)
                    .Where(s => s.ChildrenCapacity >= request.NumberOfChildren)
                    .Where(s => s.MaxPeriodInDays >= periodInDays)
                    .AsQueryable();
                
                if (request.Shelter.AllowsPets)
                {
                    shelterQuery = shelterQuery.Where(s => s.AllowsPets);
                }

                if (request.Address?.Region?.Id > 0)
                {
                    shelterQuery = shelterQuery.Where(s => s.Address.RegionId == request.Address.Region.Id);
                }

                if (request.Address?.City?.Id > 0)
                {
                    shelterQuery = shelterQuery.Where(s => s.Address.CityId == request.Address.City.Id);
                }

                result.SearchedForShelter = true;
                result.ShelterResults = await shelterQuery
                    .OrderBy(s => s.MaxPeriodInDays - periodInDays)
                    .ThenBy(s => s.AdultCapacity - request.NumberOfAdults + s.ChildrenCapacity - request.NumberOfChildren)
                    .Select(s => new SearchOffersResult.ShelterResult
                    {
                        Id = s.Id,
                        Name = s.ContactPerson.Name,
                        Phone = s.ContactPerson.Phone,
                        AdultCapacity = s.AdultCapacity,
                        ChildrenCapacity = s.ChildrenCapacity,
                        Period = s.Period,
                        Address = new AddressModel
                        {
                            Region = new RegionModel(s.Address.Region.Id, s.Address.Region.Name),
                            City = new CityModel(s.Address.City.Id, s.Address.City.Name),
                        },
                        IsActive = s.IsActive,
                    })
                    .Take(10)
                    .ToListAsync();
            }

            var now = DateTime.Now;
            var transportQuery = _dbContext.Set<Transport>()
                .Where(t => t.IsActive)
                .Where(t => !t.ExpiresOn.HasValue || t.ExpiresOn > now)
                .Where(t => t.AdultCapacity >= request.NumberOfAdults)
                .Where(t => t.ChildrenCapacity >= request.NumberOfChildren)
                .AsQueryable();

            if (request.StartingPoint?.Id > 0)
            {
                transportQuery = transportQuery.Where(t => t.BorderId == request.StartingPoint.Id);
            }

            if (request.Address?.Region?.Id > 0)
            {
                transportQuery = transportQuery.Where(s => s.Destination.RegionId == request.Address.Region.Id);
            }

            if (request.Address?.City?.Id > 0)
            {
                transportQuery = transportQuery.Where(s => s.Destination.CityId == request.Address.City.Id);
            }

            result.TransportResults = await transportQuery
                .OrderBy(t => !t.ExpiresOn.HasValue)
                .ThenBy(t => t.ExpiresOn)
                .ThenBy(t => t.AdultCapacity - request.NumberOfAdults + t.ChildrenCapacity - request.NumberOfChildren)
                .Select(t => new SearchOffersResult.TransportResult
                {
                    Id = t.Id,
                    Name = t.ContactPerson.Name,
                    Phone = t.ContactPerson.Phone,
                    AdultSeats = t.AdultCapacity,
                    ChildSeats = t.ChildrenCapacity,
                    Destination = new AddressModel
                    {
                        Region = new RegionModel(t.Destination.Region.Id, t.Destination.Region.Name),
                        City = new CityModel(t.Destination.City.Id, t.Destination.City.Name),
                    },
                    LeavesAt = t.ExpiresOn,
                    IsActive = t.IsActive,
                })
                .Take(10)
                .ToListAsync();

            return new OkObjectResult(result);
        }
    }
}
