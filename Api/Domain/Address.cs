namespace BlazorApp.Api.Domain
{
    public class Address
    {
        public int RegionId { get; set; }

        public Region Region { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
