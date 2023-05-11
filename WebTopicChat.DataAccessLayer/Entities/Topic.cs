namespace WebTopicChat.DataAccessLayer.Entities
{
    public partial class Topic
    {
        public Topic()
        {
            ClientTopics = new HashSet<ClientTopic>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }

        public virtual Client Owner { get; set; } = null!;
        public virtual ICollection<ClientTopic> ClientTopics { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
