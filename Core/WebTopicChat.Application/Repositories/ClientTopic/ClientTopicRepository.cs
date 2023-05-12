using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public dynamic? GetClientTopic()
        {
            return _context.ClientTopics;
        }

        public dynamic? AddClientTopic(int clientId, int topicId)
        { 
            if (_context.ClientTopics.SingleOrDefault(x => x.ClientId == clientId) == null && _context.ClientTopics.SingleOrDefault(y => y.TopicId == topicId) == null)
            {
                return null;
            }
            else
            {
                var newClientTopic = new Domain.Entities.ClientTopic
                {
                    TopicId = topicId,
                    ClientId = clientId,
                    CreateTime = DateTime.UtcNow,
                };
                _context.ClientTopics.Add(newClientTopic);
                _context.SaveChanges();

                return newClientTopic;
            }
        }

        public dynamic? RemoveClientTopic(int clientId, int topicId)
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
                return false;
        }
    }
}
