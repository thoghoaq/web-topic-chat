using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD:WebTopicChat.DataAccessLayer/Repositories/Topic/TopicRepository.cs
using WebTopicChat.DataAccessLayer.Context;
=======
using System.Reflection.Metadata;
using WebTopicChat.Application.Context;
>>>>>>> 40fe3ce9b7fee542c782a2542d0183f537774459:Core/WebTopicChat.Application/Repositories/Topic/TopicRepository.cs

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
            var topics = _context.Topics.Include(e => e.Owner);
            return topics;
        }

        public Domain.Entities.Topic AddTopic(string name, int ownerId)
        {
            var  entity= _context.Topics.Add(new Domain.Entities.Topic
            {
                Name = name,
                OwnerId = ownerId
            });
            _context.SaveChanges();
            return entity.Entity;
        }
    }
}
