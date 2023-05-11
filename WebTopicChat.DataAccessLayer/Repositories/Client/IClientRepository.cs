namespace WebTopicChat.DataAccessLayer.Repositories.Client
{
    public interface IClientRepository
    {
        dynamic? Get(string userName, string password);
    }
}