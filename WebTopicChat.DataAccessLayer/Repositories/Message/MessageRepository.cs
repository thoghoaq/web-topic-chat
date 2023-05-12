using WebTopicChat.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace WebTopicChat.DataAccessLayer.Repositories.Message
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TopicChatContext _context;
        public MessageRepository(TopicChatContext context) 
        {
            _context = context;
        }
        public dynamic? GetListOfTopic(int topicId)
        {
            var messages = _context.Messages.Where(e => e.TopicId.Equals(topicId)).Include(e => e.Topic).Include(e=>e.Sender);
            return messages;
        }
    }
}
