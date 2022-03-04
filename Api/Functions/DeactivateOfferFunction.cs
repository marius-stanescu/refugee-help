using System.Linq;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace BlazorApp.Api.Functions
{
    public class DeactivateOfferFunction
    {
        private readonly RefugeesDbContext _dbContext;

        public DeactivateOfferFunction(RefugeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("DeactivateOffer")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] DeactivateOfferRequest request)
        {
            var transport = _dbContext.Set<Transport>()
                .FirstOrDefault(t => t.Id == request.OfferId);

            if (transport is not null)
            {
                transport.IsActive = false;
                transport.DeactivationReason = request.Reason;
            }

            var shelter = _dbContext.Set<Shelter>()
                .FirstOrDefault(t => t.Id == request.OfferId);

            if (shelter is not null)
            {
                shelter.IsActive = false;
                shelter.DeactivationReason = request.Reason;
            }

            _dbContext.SaveChanges();

            return new OkResult();
        }
    }
}
