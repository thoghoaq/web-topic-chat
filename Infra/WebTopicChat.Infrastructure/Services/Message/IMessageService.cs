using WebTopicChat.Domain.DTOs.Response.Message;

namespace WebTopicChat.Infrastructure.Services.Message
{
    public interface IMessageServices
    {
        List<MessageResponseModel> GetMessageOfTopic(int topicId);
    }
}
