using System.Collections.Generic;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace BlazorApp.Api.Functions;

public static class GetTimePeriodsFunction
{
    [FunctionName("GetTimePeriods")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
    {
        var timePeriods = new HashSet<TimePeriod>
        {
            TimePeriod.OneToThreeDays,
            TimePeriod.ThreeDaysToAWeek,
            TimePeriod.OneToTwoWeeks,
            TimePeriod.ThreeToFourWeeks,
            TimePeriod.OneToTwoMonths,
            TimePeriod.Indefinite,
        };

        return new OkObjectResult(timePeriods);
    }
}
