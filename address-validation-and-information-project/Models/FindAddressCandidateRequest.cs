using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace AddressVerification.Models
{
    public class FindAddressCandidateRequest
    {
        [FromRoute(Name = "singleLineAddress")]
        [Required]
        public string SingleLineAddress { get; set; } = string.Empty;
        [FromRoute(Name = "magicKey")]
        [Required]
        public string MagicKey { get; set; } = string.Empty;
        [FromRoute(Name = "countryCode")]
        [Required]
        public string CountryCode { get; set; } = string.Empty;
    }
}