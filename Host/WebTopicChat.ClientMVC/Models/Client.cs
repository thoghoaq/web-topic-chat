namespace WebTopicChat.ClientMVC.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

