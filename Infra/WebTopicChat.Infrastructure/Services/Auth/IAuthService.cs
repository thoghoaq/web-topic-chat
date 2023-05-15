using WebTopicChat.Domain.DTOs.Request.Auth;
using WebTopicChat.Domain.DTOs.View.Auth;
using WebTopicChat.Domain.DTOs.View.Common;

namespace WebTopicChat.Infrastructure.Services.Auth
{
    public interface IAuthService
    {
        KeyValuePair<MessageViewModel ,LoginViewModel?> Login(string userName, string password);
        LoginViewModel Register(RegisterRequestModel model);
    }
}
