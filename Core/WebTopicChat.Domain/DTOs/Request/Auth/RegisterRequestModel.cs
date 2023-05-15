using System.ComponentModel.DataAnnotations;

namespace WebTopicChat.Domain.DTOs.Request.Auth
{
    public class RegisterRequestModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string DisplayName { get; set; } = null!;
    }
}
