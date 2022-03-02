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
        var timePeriods = new HashSet<TimePeriodModel>
        {
            new TimePeriodModel(TimePeriod.OneToThreeDays, "1 - 3 zile"),
            new TimePeriodModel(TimePeriod.ThreeDaysToAWeek, "3 - 7 zile"),
            new TimePeriodModel(TimePeriod.OneToTwoWeeks, "1 - 2 săptămâni"),
            new TimePeriodModel(TimePeriod.ThreeToFourWeeks, "3 - 4 săptămâni"),
            new TimePeriodModel(TimePeriod.OneToTwoMonths, "1 - 2 luni"),
            new TimePeriodModel(TimePeriod.Indefinite, "nedeterminat"),
        };

        return new OkObjectResult(timePeriods);
    }
}
