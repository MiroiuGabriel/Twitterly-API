using System.ComponentModel.DataAnnotations;

// Create custom data annotation to check equality of Password and CurrentPassword

namespace Twitterly_API.Dtos
{
    public record DateOfBirth
    {
        [Required, Range(1907, 2023)]
        public int Year { get; set; }
        [Required, Range(1, 12)]
        public int Month { get; set; }
        [Required, Range(1, 31)]
        public int Day { get; set; }
    }
    public record UserSignupDto
    {
        [Required, MinLength(4)]
        public string Username { get; init; } = string.Empty;
        [Required, MinLength(4)]
        public string Password { get; init; } = string.Empty;
        [Required, MinLength(4)]
        public string ConfirmPassword { get; init; } = string.Empty;
        [Required]
        public DateOfBirth DateOfBirth { get; init; } = new();
    }
}
