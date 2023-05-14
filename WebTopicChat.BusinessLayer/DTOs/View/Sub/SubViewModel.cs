
using WebTopicChat.DataAccessLayer.Entities;

namespace WebTopicChat.BusinessLayer.DTOs.View.Sub
{
    public class SubViewModel
    {
        public int ClientId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreateTime { get; set; } 
    }
}
