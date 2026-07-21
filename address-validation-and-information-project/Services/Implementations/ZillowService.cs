using AddressVerification.Configuration;
using AddressVerification.Exceptions;
using AddressVerification.Services.Interfaces;
using Microsoft.Extensions.Options;
namespace AddressVerification.Services.Implementations;

public class ZillowService : IZillowService
{
    private readonly HttpClient _httpClient;
    private readonly ZillowOptions _options;
    private readonly ILogger<ZillowService> _logger;
    public ZillowService(HttpClient httpClient, IOptions<ZillowOptions> options, ILogger<ZillowService> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
    }
    public async Task<string> GetPropertyByAddressAsync(string address, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        var requestUri = $"{_options.BaseUrl}/byaddress";
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        request.Headers.Add("x-rapidapi-host", "private-zillow.p.rapidapi.com");
        request.Headers.Add("x-rapidapi-key", _options.RapidApiKey);
        // Correct parameter name and encoding
        var uriBuilder = new UriBuilder(request.RequestUri!);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
        query["propertyaddress"] = address;
        uriBuilder.Query = query.ToString()!;
        request.RequestUri = uriBuilder.Uri;
        try
        {
            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            return content;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Private Zillow API failed for address: {Address}", address);
            throw new ExternalServiceException("Failed to fetch property information", ex);
        }
    }
}