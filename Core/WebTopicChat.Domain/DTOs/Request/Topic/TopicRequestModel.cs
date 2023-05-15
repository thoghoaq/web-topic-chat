using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
