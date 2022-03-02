using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Api.Functions;

public static class GetHousingPeriodsFunction
{
    [FunctionName("GetHousingPeriods")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
    {
        var housingPeriods = new HashSet<(HousingPeriod, string)>
        {
            (HousingPeriod.OneToThreeDays, "1 - 3 zile"),
            (HousingPeriod.ThreeDaysToAWeek, "3 - 7 zile"),
            (HousingPeriod.OneToTwoWeeks, "1 - 2 săptămâni"),
            (HousingPeriod.ThreeToFourWeeks, "3 - 4 săptămâni"),
            (HousingPeriod.OneToTwoMonths, "1 - 2 luni"),
            (HousingPeriod.Indefinite, "nedeterminat"),
        };

        return new OkObjectResult(housingPeriods.ToArray());
    }
}
