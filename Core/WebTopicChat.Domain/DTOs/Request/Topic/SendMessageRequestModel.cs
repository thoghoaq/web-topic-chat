using System.ComponentModel;

namespace WebTopicChat.Domain.DTOs.Request.Topic
{
    public class SendMessageRequestModel
    {
        public int SenderId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
