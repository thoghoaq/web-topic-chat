namespace WebTopicChat.Application.Repositories.Message
{
    public interface IMessageRepository
    {
        dynamic? GetListOfTopic(int topicId);
        dynamic? SendMessage(int topicID, int clientID, string contentMsg);
    }
}
