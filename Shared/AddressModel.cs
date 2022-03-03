namespace BlazorApp.Shared
{
    public class AddressModel
    {
        public AddressModel()
        {
            Region = new RegionModel();
            City = new CityModel();
        }

        public RegionModel Region { get; set; }

        public CityModel City { get; set; }
    }
}
