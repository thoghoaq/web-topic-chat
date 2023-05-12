namespace WebTopicChat.DataAccessLayer.Repositories.Topic
{
    public interface ITopicRepository
    {
        dynamic? GetList();
        Entities.Topic AddTopic(string name, int ownerId);
    }
}
