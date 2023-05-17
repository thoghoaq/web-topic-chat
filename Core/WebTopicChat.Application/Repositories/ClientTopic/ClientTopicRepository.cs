using WebTopicChat.Application.Context;

namespace WebTopicChat.Application.Repositories.ClientTopic
{
    public class ClientTopicRepository : IClientTopicRepository
    {
        private readonly TopicChatContext _context;

        public ClientTopicRepository(TopicChatContext context)
        {
            _context = context;
        }

        public dynamic? GetClientTopic(int clientId, int topicId)
        {
            return _context.ClientTopics.Where(x => x.ClientId == clientId && x.TopicId == topicId).SingleOrDefault();
        }

        public dynamic? AddClientTopic(int clientId, int topicId)
        {
            try
            {
                if (GetClientTopic(clientId, topicId) != null)
                {
                    return null;
                }
                else
                {
                    var newClientTopic = new Domain.Entities.ClientTopic
                    {
                        TopicId = topicId,
                        ClientId = clientId,
                    };
                    _context.ClientTopics.Add(newClientTopic);
                    _context.SaveChanges();

                    return newClientTopic;
                }
            } catch (Exception ex)
            {
                return null;
            }
        }

        public bool RemoveClientTopic(int clientId, int topicId)
        {
            try
            {
                var deleteClientTopic = _context.ClientTopics
                    .Where(x => x.TopicId == topicId && x.ClientId == clientId)
                    .SingleOrDefault();
                if (deleteClientTopic != null)
                {
                    _context.ClientTopics.Remove(deleteClientTopic);
                    _context.SaveChanges();
                    return true;
                }
                else 
                {
                    return false; 
                }
            } 
            catch(Exception)
            { 
                return false; 
            }
        }
    }
}
