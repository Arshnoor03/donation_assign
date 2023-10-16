using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace comp4976_assignment.Models
{
    public class CustomUsers : IdentityUser
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}