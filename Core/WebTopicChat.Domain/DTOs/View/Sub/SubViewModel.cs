
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.Domain.DTOs.View.Sub
{
    public class SubViewModel
    {
        public int ClientId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreateTime { get; set; } 
    }
}
