using System.ComponentModel.DataAnnotations;

namespace Notes.Api.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 20 characters")]
        public required string Password { get; set; }
    }

    public class UserForLoginDto
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}