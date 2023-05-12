namespace WebTopicChat.ClientMVC.Models
{
    public class ClientTopic
    {
        public int ClientId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
