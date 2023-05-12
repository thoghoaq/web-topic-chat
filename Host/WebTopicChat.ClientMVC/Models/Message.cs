namespace WebTopicChat.ClientMVC.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreateTime { get; set; }
        public int TopicId { get; set; }
        public int SenderId { get; set; }
    }
}
