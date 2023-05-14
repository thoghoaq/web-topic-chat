using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebTopicChat.DataAccessLayer.Context;

namespace WebTopicChat.DataAccessLayer.Repositories.Topic
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TopicChatContext _context;
        public TopicRepository(TopicChatContext context) 
        {
            _context = context;
        }

        public dynamic? GetList()
        {
            var topics = _context.Topics.Include(e => e.Owner);
            return topics;
        }

        public Entities.Topic AddTopic(string name, int ownerId)
        {
            var  entity= _context.Topics.Add(new Entities.Topic
            {
                Name = name,
                OwnerId = ownerId
            });
            _context.SaveChanges();
            return entity.Entity;
        }
    }
}
