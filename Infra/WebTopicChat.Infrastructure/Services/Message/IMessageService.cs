using WebTopicChat.Domain.DTOs.Request.Message;
using WebTopicChat.Domain.DTOs.Response.Message;

namespace WebTopicChat.Infrastructure.Services.Message
{
    public interface IMessageServices
    {
        MessageRequestModel SendMessage(int topicId, int clientId, string Msg);
        List<MessageResponseModel> GetMessageOfTopic(int topicId);
    }
}
