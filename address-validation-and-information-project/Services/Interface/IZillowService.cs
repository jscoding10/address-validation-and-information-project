namespace AddressVerification.Services.Interfaces;

public interface IZillowService
{
    Task<string> GetPropertyByAddressAsync(string address, CancellationToken cancellationToken = default);
}