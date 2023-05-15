namespace WebTopicChat.ClientMVC.Models
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsSubcribed { get; set; }
    }

}
