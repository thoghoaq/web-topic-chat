using Microsoft.AspNetCore.Mvc;
using WebTopicChat.BusinessLayer.Services.Message;
using WebTopicChat.BusinessLayer.Services.Topic;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("topic")]   
    
    public class TopicController : ControllerBase
    {
        private readonly ITopicServices _topicService;
        private readonly IMessageServices _messageService;

        public TopicController(ITopicServices topicService, IMessageServices messageServices)
        {
            _topicService = topicService;
            _messageService = messageServices;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_topicService.GetTopics());
        }

        [HttpGet("{topicId}/message")]
        public IActionResult GetListOfTopic(int topicId)
        {
            return Ok(_messageService.GetMessageOfTopic(topicId));
        }

        [HttpPost]
        public IActionResult AddTopic(string name, int ownerId)
        {
            return Ok(_topicService.AddTopic(name, ownerId));
        }
    }
}
