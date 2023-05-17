namespace WebTopicChat.Application.Repositories.Client
{
    public interface IClientRepository
    {
        dynamic? Get(string userName, string password);
        Domain.Entities.Client? Create(string userName, string password, string displayName);
    }
}