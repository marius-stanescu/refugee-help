using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace BlazorApp.Api.Functions
{
    public class AddOfferFunction
    {
        private readonly RefugeesDbContext _dbContext;

        public AddOfferFunction(RefugeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("AddOffer")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] AddOfferRequest request)
        {
            if (request.Transport.IsOffered)
            {
                var transport = new Transport
                {
                    ContactPerson = new ContactPerson
                    {
                        Name = request.Name,
                        Phone = request.Phone,
                    },
                    StartingPoint = request.Transport.StartingPoint,
                    Destination = new Address
                    {
                        RegionId = request.Transport.Destination.Region.Id,
                        CityId = request.Transport.Destination.City.Id,
                    },
                    AdultCapacity = request.Transport.AdultSeats,
                    ChildrenCapacity = request.Transport.ChildSeats,
                    ExpiresOn = request.Transport.ExpiresOn,
                };

                _dbContext.Add(transport);
            }

            if (request.Shelter.IsOffered)
            {
                var shelter = new Shelter
                {
                    ContactPerson = new ContactPerson
                    {
                        Name = request.Name,
                        Phone = request.Phone,
                    },
                    Address = new Address
                    {
                        RegionId = request.Transport.IsOffered
                            ? request.Transport.Destination.Region.Id
                            : request.Shelter.Address.Region.Id,
                        CityId = request.Transport.IsOffered
                            ? request.Transport.Destination.City.Id
                            : request.Shelter.Address.City.Id,
                    },
                    AdultCapacity = request.Shelter.AdultCapacity,
                    ChildrenCapacity = request.Shelter.ChildrenCapacity,
                    AllowsPets = request.Shelter.AllowsPets,
                    MaxPeriodInDays = request.Shelter.Period.InDays(),
                };

                _dbContext.Add(shelter);
            }

            _dbContext.SaveChanges();

            return new OkResult();
        }
    }
}
