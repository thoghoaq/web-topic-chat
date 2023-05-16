namespace WebTopicChat.ClientMVC.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreateTime { get; set; }
        public string TopicName { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
    }
}
