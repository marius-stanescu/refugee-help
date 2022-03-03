using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Api.Functions;

public static class GetStartingPointsFunction
{
    [FunctionName("GetStartingPoints")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
    {
        var startingPoints = new HashSet<string>
        {
            "Vama Isaccea", "Vama Tulcea", "Vama Sighetu Marmației", "Vama Siret", "Vama Câmpulung la Tisa", "Vama Fălciu", "Vama Galați", "Vama Albița", "Vama Nicolina", "Vama Oancea", "Vama Suculeni", "Vama Stânca",
        };

        return new OkObjectResult(startingPoints.ToArray());
    }
}
