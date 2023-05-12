namespace WebTopicChat.Application.Repositories.Client
{
    public interface IClientRepository
    {
        dynamic? Get(string userName, string password);
    }
}