using Microsoft.EntityFrameworkCore;
using WebTopicChat.Application.Context;
using WebTopicChat.Domain.Entities;

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
                .Include(e => e.Owner)
                .OrderByDescending(e => e.CreateTime);
            return topics.ToList();
        }

        public Domain.Entities.Topic? AddTopic(string name, int ownerId)
        {
            try
            {
                var entity = _context.Topics.Add(new Domain.Entities.Topic
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
                entity.Entity.Owner = _context.Clients.First(e => e.Id.Equals(ownerId));
                return entity.Entity;
            }catch
            {
                return null;
            }
        }
    }
}
