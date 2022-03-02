using System.Collections.Generic;

namespace BlazorApp.Api.Domain
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
