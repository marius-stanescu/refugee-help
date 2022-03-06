using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorApp.Api.Functions;

public class MigrateAndSeedDbFunction
{
    private readonly RefugeesDbContext _dbContext;

    public MigrateAndSeedDbFunction(RefugeesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("MigrateAndSeedDbFunction")]
    public void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        ILogger log,
        ExecutionContext context)
    {
        log.LogInformation($"Migrate and seed db function started at: {DateTime.Now}");

        try
        {
            _dbContext.Database.Migrate();

            if (!_dbContext.Set<Border>().Any())
            {
                var borders = Cache.Borders.Select(b => new Border
                {
                    Id = b.Id,
                    Name = b.Name,
                    NormalizedName = b.NormalizedName,
                });
                _dbContext.AddRange(borders);
            }

            if (!_dbContext.Set<City>().Any()
                && !_dbContext.Set<Region>().Any())
            {
                var filePath = Path.Combine(context.FunctionAppDirectory + "\\Files\\RegionsAndCities.json");
                var json = File.ReadAllText(filePath);
                var regions = JsonConvert.DeserializeObject<List<Region>>(json);

                _dbContext.AddRange(regions);
            }

            _dbContext.SaveChanges();

            log.LogInformation($"Migrate and seed db function executed at: {DateTime.Now}");
        }
        catch (Exception ex)
        {
            log.LogCritical(ex, "Error while running migrations or seeding the db.");
        }
    }
}
