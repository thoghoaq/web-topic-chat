using WebTopicChat.Domain.DTOs.Response.Message;

namespace WebTopicChat.Infrastructure.Services.Message
{
    public interface IMessageServices
    {
        MessageResponseModel SendMessage(int topicId, int clientId, string Msg);
        List<MessageResponseModel> GetMessageOfTopic(int topicId);
    }
}
