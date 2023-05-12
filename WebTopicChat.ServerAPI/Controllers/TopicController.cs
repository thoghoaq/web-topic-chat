using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebTopicChat.BusinessLayer.Services.Auth;
using WebTopicChat.BusinessLayer.Services.Topic;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("topic")]   
    
    public class TopicController : ControllerBase
    {
        private readonly ITopicServices _topicService;

        public TopicController(ITopicServices topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_topicService.GetTopics());
        }
    }
}
