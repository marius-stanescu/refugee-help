using System.Globalization;
using System.Linq;
using System.Text;
using BlazorApp.Api.Data;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Diacritics.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace BlazorApp.Api.Functions
{
    public class GetCitiesFunction
    {
        private readonly RefugeesDbContext _dbContext;

        public GetCitiesFunction(RefugeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("GetCities")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var regionId = int.Parse(req.Query["regionId"]);
            var normalizedName = LookupNormalize(req.Query["name"].ToString());
            var cities = _dbContext.Set<City>()
                .Where(c => c.RegionId == regionId)
                .Where(c => c.NormalizedName.Contains(normalizedName))
                .OrderByDescending(c => c.Population)
                .Take(30)
                .Select(r => new CityModel { Id = r.Id, Name = r.Name })
                .ToList();

            return new OkObjectResult(cities);
        }

        private static string LookupNormalize(string input)
        {
            if (input == null)
            {
                return "";
            }

            var inputWithoutDiacritics = input.RemoveDiacritics();
            var stringBuilder = new StringBuilder(inputWithoutDiacritics.Length);
            var previousCharWasSeparator = false;

            foreach (char c in inputWithoutDiacritics)
            {
                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                    case UnicodeCategory.OpenPunctuation:
                    case UnicodeCategory.ClosePunctuation:
                    case UnicodeCategory.MathSymbol:
                        if (previousCharWasSeparator)
                        {
                            break;
                        }
                        stringBuilder.Append('_');
                        previousCharWasSeparator = true;
                        break;
                    case UnicodeCategory.LowercaseLetter:
                        previousCharWasSeparator = false;
                        stringBuilder.Append(char.ToUpper(c, CultureInfo.InvariantCulture));
                        break;
                    default:
                        previousCharWasSeparator = false;
                        stringBuilder.Append(c);
                        break;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
