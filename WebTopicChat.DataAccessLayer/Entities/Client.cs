namespace WebTopicChat.DataAccessLayer.Entities
{
    public partial class Client
    {
        public Client()
        {
            ClientTopics = new HashSet<ClientTopic>();
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ClientTopic> ClientTopics { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
