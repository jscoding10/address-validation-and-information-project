using System.Text.Json.Serialization;
namespace AddressVerification.Models;

public class ArcGisSuggestResponse
{
    [JsonPropertyName("suggestions")]
    public List<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    public class Suggestion
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
        [JsonPropertyName("magicKey")]
        public string MagicKey { get; set; } = string.Empty;
        [JsonPropertyName("isCollection")]
        public bool IsCollection { get; set; }
    }
}