namespace WebTopicChat.Domain.DTOs.Response.Message
{
    public class MessageResponseModel
    {
        public int MessageId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreateTime { get; set; }
        public string? TopicName { get; set; }
        public string? SenderName { get; set; }
    }
}
