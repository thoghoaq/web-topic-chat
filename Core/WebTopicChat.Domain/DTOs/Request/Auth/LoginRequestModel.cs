using System.ComponentModel.DataAnnotations;

namespace WebTopicChat.Domain.DTOs.Request.Auth
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required] 
        public string Password { get; set; } = null!;
    }
}
