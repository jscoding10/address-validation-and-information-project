using System.Text.Json.Serialization;
namespace AddressVerification.Models;

public class ArcGisFindAddressCandidateResponse
{
    [JsonPropertyName("spatialReference")]
    public SpatialReference SpatialReference { get; set; } = new();
    [JsonPropertyName("candidates")]
    public List<Candidate> Candidates { get; set; } = new();
    public class Candidate
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public Location Location { get; set; } = new();
        [JsonPropertyName("score")]
        public double Score { get; set; }
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; } = new();
        [JsonPropertyName("extent")]
        public Extent Extent { get; set; } = new();
    }
    public class Location
    {
        [JsonPropertyName("x")]
        public double X { get; set; }
        [JsonPropertyName("y")]
        public double Y { get; set; }
    }
    public class Attributes
    {
        [JsonPropertyName("AddNum")]
        public string? AddNum { get; set; }
        [JsonPropertyName("StAddr")]
        public string? StAddr { get; set; }
        [JsonPropertyName("StName")]
        public string? StName { get; set; }
        [JsonPropertyName("StType")]
        public string? StType { get; set; }
        [JsonPropertyName("Country")]
        public string? Country { get; set; }
        [JsonPropertyName("StDir")]
        public string? StDir { get; set; }
        [JsonPropertyName("City")]
        public string? City { get; set; }
        [JsonPropertyName("RegionAbbr")]
        public string? RegionAbbr { get; set; }
        [JsonPropertyName("Postal")]
        public string? Postal { get; set; }
    }
    public class Extent
    {
        [JsonPropertyName("xmin")]
        public double Xmin { get; set; }
        [JsonPropertyName("ymin")]
        public double Ymin { get; set; }
        [JsonPropertyName("xmax")]
        public double Xmax { get; set; }
        [JsonPropertyName("ymax")]
        public double Ymax { get; set; }
    }
}
public class SpatialReference
{
    [JsonPropertyName("wkid")]
    public int Wkid { get; set; }
    [JsonPropertyName("latestWkid")]
    public int LatestWkid { get; set; }
}