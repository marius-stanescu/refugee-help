using System.Linq;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace BlazorApp.Api.Functions
{
    public class GetRegionsFunction
    {
        private readonly RefugeesDbContext _dbContext;

        public GetRegionsFunction(RefugeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetRegions")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var regions = _dbContext.Set<Region>()
                .Select(r => new RegionModel { Id = r.Id, Name = r.Name })
                .ToList();

            return new OkObjectResult(regions);
        }
    }
}
