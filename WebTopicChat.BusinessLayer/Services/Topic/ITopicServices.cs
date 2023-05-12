using WebTopicChat.BusinessLayer.DTOs.Response.Topic;

namespace WebTopicChat.BusinessLayer.Services.Topic
{
    public interface ITopicServices
    {
        List<TopicResponseModel> GetTopics();
        TopicResponseModel AddTopic(string name, int ownerId);
    }
}
