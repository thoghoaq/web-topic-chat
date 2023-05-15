namespace WebTopicChat.Application.Repositories.Message
{
    public interface IMessageRepository
    {
        dynamic? GetListOfTopic(int topicId);
        dynamic? SendMessage(int topicID, int clientID, string contentMsg);
        Domain.Entities.Message? GetMessage(int id);
        Domain.Entities.Message CreateMessage(int topicId,int senderId, string content);
    }
}
