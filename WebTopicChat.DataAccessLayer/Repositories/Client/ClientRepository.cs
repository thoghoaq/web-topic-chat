using WebTopicChat.DataAccessLayer.Context;

namespace WebTopicChat.DataAccessLayer.Repositories.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly TopicChatContext _context;

        public ClientRepository(TopicChatContext context)
        {
            _context = context;
        }

        public dynamic? Get(string userName, string password)
        {
            var client = _context.Clients.SingleOrDefault(e => e.UserName.Equals(userName) && e.Password.Equals(password));
            return client;
        }
    }
}
