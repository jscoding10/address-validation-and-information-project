using System.Text.Json;
using AddressVerification.Configuration;
using AddressVerification.Exceptions;
using AddressVerification.Models;
using AddressVerification.Services.Interfaces;
using Microsoft.Extensions.Options;
namespace AddressVerification.Services.Implementations;

public class ArcGisGeocodingService : IAddressGeocodingService
{
    private readonly HttpClient _httpClient;
    private readonly ArcGisOptions _options;
    private readonly ILogger<ArcGisGeocodingService> _logger;
    public ArcGisGeocodingService(HttpClient httpClient, IOptions<ArcGisOptions> options, ILogger<ArcGisGeocodingService> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
    }
    public async Task<ArcGisSuggestResponse> GetAddressSuggestionsAsync(string address, string countryCode, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        ArgumentException.ThrowIfNullOrWhiteSpace(countryCode);
        var addressData = new Dictionary<string, string>
{
{ "text", address },
{ "countryCode", countryCode },
{ "f", "pjson" },
};
        var requestBody = new FormUrlEncodedContent(addressData);
        try
        {
            var response = await _httpClient.PostAsync(_options.SuggestUrl, requestBody, cancellationToken);

            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonSerializer.Deserialize<ArcGisSuggestResponse>(json);
            return result ?? new ArcGisSuggestResponse();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "ArcGIS API request failed for address: {Address}", address);
            throw new ExternalServiceException("Failed to fetch address suggestions", ex);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize ArcGIS response");
            throw;
        }
    }
   
}