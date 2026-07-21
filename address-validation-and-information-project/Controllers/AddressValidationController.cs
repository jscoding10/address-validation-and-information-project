using AddressVerification.Models;
using AddressVerification.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AddressVerification.Exceptions;
namespace AddressVerification.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressValidationController : ControllerBase
{
    private readonly IAddressGeocodingService _geocodingService;
    // Constructor for dependency injection
    public AddressValidationController(IAddressGeocodingService geocodingService)
    {
        _geocodingService = geocodingService;
    }

    [HttpGet("suggest/{address}/{countryCode}")]
    public async Task<ActionResult<ArcGisSuggestResponse>> GetAddressSuggestion(
    [FromRoute] AddressSuggestionRequest request,
    CancellationToken cancellationToken)
    {
        try
        {
            var result = await _geocodingService.GetAddressSuggestionsAsync(
            request.Address, request.CountryCode, cancellationToken);
            return Ok(result);
        }
        catch (ExternalServiceException)
        {
            return StatusCode(502, "External geocoding suggest service unavailable");
        }
        catch (Exception)
        {
            return StatusCode(500, "An unexpected error occurred");
        }
    }
    [HttpGet("findAddressCandidate/{singleLineAddress}/{magicKey}/{countryCode}")]
    public async Task<ActionResult<ArcGisFindAddressCandidateResponse>> GetAddressCandidate(
    [FromRoute] FindAddressCandidateRequest request,
    CancellationToken cancellationToken)
    {
        try
        {
            var result = await _geocodingService.FindAddressCandidatesAsync(
            request.SingleLineAddress, request.MagicKey, request.CountryCode, cancellationToken);
            return Ok(result);
        }
        catch (ExternalServiceException)
        {
            return StatusCode(502, "External geocoding service unavailable");
        }
        catch (Exception)
        {
            return StatusCode(500, "An unexpected error occurred");
        }
    }
}
// Input validation, rate limiting, and caching
// In produciton would move the api key into User Secrets