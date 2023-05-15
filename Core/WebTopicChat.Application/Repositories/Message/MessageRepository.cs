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

        public Domain.Entities.Message CreateMessage(int topicId,int senderId, string content)
        {
            var message = new Domain.Entities.Message
            {
                Content = content,
                SenderId = senderId,
                CreateTime = DateTime.Now,
                TopicId = topicId,
            };
            var response = _context.Messages.Add(message);
            _context.SaveChanges();
            return response.Entity;
        }

        public dynamic? GetListOfTopic(int topicId)
        {
            var messages = _context.Messages
                .Where(e => e.TopicId
                .Equals(topicId))
                .Include(e => e.Topic)
                .Include(e=>e.Sender)
                .OrderBy(e => e.CreateTime);
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
                var newMsg = new Domain.Entities.Message
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
        public Domain.Entities.Message? GetMessage(int id)
        {
            return _context.Messages
                .Include(e => e.Topic)
                .Include(e => e.Sender)
                .SingleOrDefault(e => e.Id == id);
        }
    }
}
