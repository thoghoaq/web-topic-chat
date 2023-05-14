
namespace WebTopicChat.DataAccessLayer.Repositories.Message
{
    public interface IMessageRepository
    {
        dynamic? GetListOfTopic(int topicId);
        dynamic? SendMessage(int topicID, int clientID, string contentMsg);
    }
}
