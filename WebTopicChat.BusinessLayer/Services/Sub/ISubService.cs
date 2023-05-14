namespace WebTopicChat.BusinessLayer.Services.Sub
{
    public interface ISubService
    {
        dynamic? Subscribe(int clientId, int topicId);
        dynamic? Unsubscribe(int clientId, int topicId);
    }
}
