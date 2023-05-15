using WebTopicChat.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace WebTopicChat.Application.Repositories.Message
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

        public dynamic? SendMessage(int topicId, int clientId, string contentMsg)
        {
            if (_context.ClientTopics.SingleOrDefault(x => x.TopicId == topicId && x.ClientId == clientId) == null)
            {
                return null;
            }
            else
            {
                var newMsg = new Entities.Message
                {
                    TopicId = topicId,
                    SenderId = clientId,
                    CreateTime = DateTime.Now,
                    Content = contentMsg
                };
                _context.Messages.Add(newMsg);
                _context.SaveChanges();

                return newMsg;
            }
        }
    }
}
