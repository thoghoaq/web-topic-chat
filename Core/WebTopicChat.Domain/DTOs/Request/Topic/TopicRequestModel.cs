using System.ComponentModel.DataAnnotations;

namespace WebTopicChat.Domain.DTOs.Request.Topic
{
    public class TopicRequestModel
    {
        [Required]  
        public string name { get; set; }
        [Required]
        public int ownerId { get; set; }
    }
}
