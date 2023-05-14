using WebTopicChat.BusinessLayer.DTOs.Response.Message;

namespace WebTopicChat.BusinessLayer.Services.Message
{
    public interface IMessageServices
    {
        MessageResponseModel SendMessage(int topicId, int clientId, string Msg);
        List<MessageResponseModel> GetMessageOfTopic(int topicId);
    }
}
