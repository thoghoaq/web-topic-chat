using WebTopicChat.BusinessLayer.DTOs.View.Auth;
using WebTopicChat.BusinessLayer.DTOs.View.Common;

namespace WebTopicChat.BusinessLayer.Services.Auth
{
    public interface IAuthService
    {
        KeyValuePair<MessageViewModel ,LoginViewModel?> Login(string userName, string password);
    }
}
