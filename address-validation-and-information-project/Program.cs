using AddressVerification.Configuration;
using AddressVerification.Services.Implementations;
using AddressVerification.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);
// Add services
builder.Services.AddControllers();
builder.Services.AddOpenApi();
// Arc Gis Configuration
builder.Services.Configure<ArcGisOptions>(builder.Configuration.GetSection("ArcGis"));
// Infrastructure
builder.Services.AddHttpClient<IAddressGeocodingService, ArcGisGeocodingService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(15);
});
// Zillow Configuration
builder.Services.Configure<ZillowOptions>(builder.Configuration.GetSection("Zillow"));
// Register Zillow service
builder.Services.AddHttpClient<IZillowService, ZillowService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(20);
});
// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();
// Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();