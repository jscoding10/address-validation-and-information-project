namespace AddressVerification.Configuration;

public class ZillowOptions
{
    public string BaseUrl { get; set; } = "https://private-zillow.p.rapidapi.com";
    public string RapidApiKey { get; set; } = string.Empty;
}