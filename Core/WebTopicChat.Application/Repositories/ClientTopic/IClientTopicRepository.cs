namespace WebTopicChat.Application.Repositories.ClientTopic
{
    public interface IClientTopicRepository
    {
        dynamic? AddClientTopic(int clientId, int topicId);
        dynamic? RemoveClientTopic(int clientId, int topicId);
        dynamic? GetClientTopic();
    }
}
