using WebTopicChat.Domain.DTOs.Response.Topic;

namespace WebTopicChat.Infrastructure.Services.Topic
{
    public interface ITopicServices
    {
        List<TopicResponseModel> GetTopics();
        TopicResponseModel AddTopic(string name, int ownerId);
    }
}
