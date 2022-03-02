using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Api;

public static class StartingPointsFunction
{
    [FunctionName("StartingPoints")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        var startingPoints = new HashSet<string>
        {
            "Oriunde",
            "Vama Isaccea", "Vama Tulcea", "Vama Sighetu Marmației", "Vama Siret", "Vama Câmpulung la Tisa", "Vama Fălciu", "Vama Galați", "Vama Albița", "Vama Nicolina", "Vama Oancea", "Vama Suculeni", "Vama Stânca",
        };

        return new OkObjectResult(startingPoints.ToArray());
    }
}
