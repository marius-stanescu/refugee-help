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
    }
}
