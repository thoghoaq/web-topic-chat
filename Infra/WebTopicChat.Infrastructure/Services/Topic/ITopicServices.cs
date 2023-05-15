using WebTopicChat.Domain.DTOs.Request.Topic;
using WebTopicChat.Domain.DTOs.Response.Message;
using WebTopicChat.Domain.DTOs.Response.Topic;

namespace WebTopicChat.Infrastructure.Services.Topic
{
    public interface ITopicServices
    {
        List<TopicResponseModel> GetTopics(int clientId);
        TopicResponseModel AddTopic(string name, int ownerId);
        MessageResponseModel SendMessage(int id, SendMessageRequestModel requestModel);
    }
}
