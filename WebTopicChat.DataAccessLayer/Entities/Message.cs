namespace WebTopicChat.DataAccessLayer.Entities
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreateTime { get; set; }
        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; } = null!;
    }
}
