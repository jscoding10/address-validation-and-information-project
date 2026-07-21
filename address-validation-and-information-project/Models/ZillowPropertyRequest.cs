using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace AddressVerification.Models
{
    public class ZillowPropertyRequest
    {
        [FromRoute(Name = "address")]
        [Required]
        [MinLength(3)]
        public string Address { get; set; } = string.Empty;
    }
}