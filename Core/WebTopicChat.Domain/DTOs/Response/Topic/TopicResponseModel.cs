namespace WebTopicChat.Domain.DTOs.Response.Topic
{
    public class TopicResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public string OwnerName { get; set; } = null!;
        public DateTime CreateTime { get; set; }
        public bool IsSubcribed { get; set; }
    }
}
