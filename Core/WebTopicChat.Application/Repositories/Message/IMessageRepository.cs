namespace WebTopicChat.Application.Repositories.Message
{
    public interface IMessageRepository
    {
        dynamic? GetListOfTopic(int topicId);
        Domain.Entities.Message? GetMessage(int id);
        Domain.Entities.Message CreateMessage(int topicId,int senderId, string content);
    }
}
