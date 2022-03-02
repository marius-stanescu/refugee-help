namespace BlazorApp.Api.Domain;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    /// <summary>
    /// The name without diacritics or any special symbols. It is used for searching.
    /// </summary>
    public string NormalizedName { get; set; }

    public string Slug { get; set; }

    public int Population { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public int DisplayOrder { get; set; }

    public int RegionId { get; set; }

    public Region Region { get; set; }
}
