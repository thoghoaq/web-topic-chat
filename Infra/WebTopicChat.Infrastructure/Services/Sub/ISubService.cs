namespace WebTopicChat.Infrastructure.Services.Sub
{
    public interface ISubService
    {
        dynamic? Subscribe(int clientId, int topicId);
        bool Unsubscribe(int clientId, int topicId);
    }
}
