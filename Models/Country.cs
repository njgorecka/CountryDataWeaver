namespace CountryDataWeaver.Models;

public class Country
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string OfficialName { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public string Capital { get; set; }
    public string FlagPngUrl { get; set; }
    public long Population { get; set; }
    public double Area { get; set; }
    public DateTime ImportedAt { get; set; }
}