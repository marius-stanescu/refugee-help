namespace BlazorApp.Shared
{
    public class CityModel
    {
        public CityModel()
        { }

        public CityModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public int Population { get; set; }

        public int RegionId { get; set; }
    }
}
