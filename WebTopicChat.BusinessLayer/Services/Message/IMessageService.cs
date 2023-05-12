using WebTopicChat.BusinessLayer.DTOs.Response.Message;

namespace WebTopicChat.BusinessLayer.Services.Message
{
    public interface IMessageServices
    {
        List<MessageResponseModel> GetMessageOfTopic(int topicId);
    }
}
