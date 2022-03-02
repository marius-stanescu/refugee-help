using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorApp.Api.Functions;

public class SeedDataFunction
{
    private readonly RefugeesDbContext _dbContext;

    public SeedDataFunction(RefugeesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("SeedDataFunction")]
    public void Run(
        [TimerTrigger("0 0 0 1 1 *", RunOnStartup = true)] TimerInfo timer,
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
