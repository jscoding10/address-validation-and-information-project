using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace AddressVerification.Models
{
    public class AddressSuggestionRequest
    {
        [FromRoute(Name = "address")]
        [Required]
        [MinLength(3)]
        public string Address { get; set; } = string.Empty;
        [FromRoute(Name = "countryCode")]
        [Required]
        [StringLength(2)]
        public string CountryCode { get; set; } = string.Empty;
    }
}