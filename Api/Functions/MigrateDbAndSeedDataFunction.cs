using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorApp.Api.Functions;

public class MigrateDbAndSeedDataFunction
{
    private readonly RefugeesDbContext _dbContext;

    public MigrateDbAndSeedDataFunction(RefugeesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("MigrateDbAndSeedDataFunction")]
    public void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        ILogger log,
        ExecutionContext context)
    {
        log.LogInformation($"SeedData function started at: {DateTime.Now}");

        try
        {
            _dbContext.Database.Migrate();

            if (_dbContext.Set<City>().Any() || _dbContext.Set<Region>().Any())
            {
                return;
            }

            var filePath = Path.Combine(context.FunctionAppDirectory + "\\Files\\RegionsAndCities.json");
            var json = File.ReadAllText(filePath);
            var regions = JsonConvert.DeserializeObject<List<Region>>(json);

            _dbContext.AddRange(regions);
            _dbContext.SaveChanges();

            log.LogInformation($"SeedData function executed at: {DateTime.Now}");
        }
        catch (Exception ex)
        {
            log.LogCritical(ex, "Error while running migrations or seeding the db.");
        }
    }
}
