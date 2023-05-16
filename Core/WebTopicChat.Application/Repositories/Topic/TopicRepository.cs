using Microsoft.EntityFrameworkCore;
using WebTopicChat.Application.Context;

namespace WebTopicChat.Application.Repositories.Topic
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
            var topics = _context.Topics
                .Include(e => e.ClientTopics)
                .Include(e => e.Owner).OrderByDescending(e => e.CreateTime);
            return topics.ToList();
        }

        public Domain.Entities.Topic AddTopic(string name, int ownerId)
        {
            var  entity= _context.Topics.Add(new Domain.Entities.Topic
            {
                Name = name,
                OwnerId = ownerId,
                CreateTime = DateTime.Now,
            });
            _context.SaveChanges();
            _context.ClientTopics.Add(new Domain.Entities.ClientTopic
            {
                ClientId = ownerId,
                TopicId = entity.Entity.Id
            });
            _context.SaveChanges();
            return entity.Entity;
        }
    }
}
