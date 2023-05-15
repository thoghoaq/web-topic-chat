using System.ComponentModel.DataAnnotations;

namespace WebTopicChat.Domain.DTOs.View.Sub
{
    public class SubViewModel
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int TopicId { get; set; }
    }
}
