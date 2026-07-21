using System.Text.Json.Serialization;
namespace AddressVerification.Models;

public class ZillowPropertyResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("Source")]
    public string? Source { get; set; }

    [JsonPropertyName("PropertyAddress")]
    public ZillowPropertyAddress? PropertyAddress { get; set; }

    [JsonPropertyName("PropertyZPID")]
    public long PropertyZpid { get; set; }

    [JsonPropertyName("Price")]
    public decimal Price { get; set; }

    [JsonPropertyName("zestimate")]
    public decimal Zestimate { get; set; }

    [JsonPropertyName("Bedrooms")]
    public int Bedrooms { get; set; }

    [JsonPropertyName("Area(sqft)")]
    public int AreaSquareFeet { get; set; }

    [JsonPropertyName("yearBuilt")]
    public int YearBuilt { get; set; }

    [JsonPropertyName("daysOnZillow")]
    public int DaysOnZillow { get; set; }

    [JsonPropertyName("PropertyZillowURL")]
    public string? PropertyZillowUrl { get; set; }
}

public class ZillowPropertyAddress
{
    [JsonPropertyName("streetAddress")]
    public string? StreetAddress { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("zipcode")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("neighborhood")]
    public string? Neighborhood { get; set; }

    [JsonPropertyName("community")]
    public string? Community { get; set; }

    [JsonPropertyName("subdivision")]
    public string? Subdivision { get; set; }
}