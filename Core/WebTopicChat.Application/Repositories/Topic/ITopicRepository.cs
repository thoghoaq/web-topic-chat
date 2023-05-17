namespace WebTopicChat.Application.Repositories.Topic
{
    public interface ITopicRepository
    {
        dynamic? GetList();
        Domain.Entities.Topic? AddTopic(string name, int ownerId);
    }
}
