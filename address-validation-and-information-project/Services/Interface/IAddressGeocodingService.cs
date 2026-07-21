using AddressVerification.Models;
namespace AddressVerification.Services.Interfaces;

public interface IAddressGeocodingService
{
    Task<ArcGisSuggestResponse> GetAddressSuggestionsAsync(string address, string countryCode, CancellationToken cancellationToken = default);
   
}