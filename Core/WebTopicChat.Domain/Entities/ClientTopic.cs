namespace WebTopicChat.Domain.Entities
{
    public partial class ClientTopic
    {
        public int ClientId { get; set; }
        public int TopicId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
