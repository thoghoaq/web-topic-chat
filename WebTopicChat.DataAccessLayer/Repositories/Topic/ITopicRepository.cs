namespace WebTopicChat.DataAccessLayer.Repositories.Topic
{
    public interface ITopicRepository
    {
        dynamic? GetList();
        bool AddTopic(string name, int ownerId);
    }
}
