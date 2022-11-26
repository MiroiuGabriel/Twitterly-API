using System.ComponentModel.DataAnnotations;

namespace Twitterly_API.Dtos
{
    public record UserLoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
