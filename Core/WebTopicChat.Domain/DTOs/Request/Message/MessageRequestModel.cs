using System.ComponentModel.DataAnnotations;

namespace WebTopicChat.Domain.DTOs.Request.Message
{
    public class MessageRequestModel
    {
        [Required]
        public int clientId {  get; set; }
        [Required]
        public int topicId { get; set; }
        [Required]
        public string Content { get; set; } = null!;
    }
}
