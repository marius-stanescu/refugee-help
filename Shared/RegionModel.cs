namespace BlazorApp.Shared
{
    public class RegionModel
    {
        public RegionModel()
        { }

        public RegionModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
