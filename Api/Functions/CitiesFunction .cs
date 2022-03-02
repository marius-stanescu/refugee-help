using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Api;

public static class CitiesFunction
{
    [FunctionName("Cities")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        var cities = new HashSet<string>
        {
            "Oriunde", "Cluj-Napoca", "București", "Oradea",
        };

        return new OkObjectResult(cities.ToArray());
    }
}
