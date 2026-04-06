using System.Text.Json.Serialization;

namespace CountryDataWeaver.Models;

public class RestCountryApiResponse
{
    [JsonPropertyName("name")] public CountryName Name { get; set; } = new();

    [JsonPropertyName("region")] public string Region { get; set; } = "";
    
    [JsonPropertyName("subregion")] public string Subregion { get; set; } = "";
    
    [JsonPropertyName("capital")] public List<string>? Capital { get; set; }
    
    [JsonPropertyName("population")] public long Population { get; set; }
    
    [JsonPropertyName("area")] public double Area { get; set; }

    [JsonPropertyName("flags")] public CountryFlags Flags { get; set; } = new();
}

public class CountryName
{
    [JsonPropertyName("common")] public string Common { get; set; } = "";
    [JsonPropertyName("offivcial")] public string Official { get; set; } = "";
}

public class CountryFlags
{
    [JsonPropertyName("png")] public string Png { get; set; } = "";
}