namespace AddressVerification.Configuration;

public class ArcGisOptions
{
    public string SuggestUrl { get; set; } = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/suggest";
    public string FindAddressCandidatesUrl { get; set; } = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/findAddressCandidates";
}