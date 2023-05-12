using Microsoft.EntityFrameworkCore;
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
    }
}
