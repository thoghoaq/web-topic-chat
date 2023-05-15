using Microsoft.AspNetCore.Mvc;
using WebTopicChat.Domain.DTOs.Request.Message;
using WebTopicChat.Domain.DTOs.Request.Topic;
using WebTopicChat.Infrastructure.Services.Message;
using WebTopicChat.Infrastructure.Services.Topic;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("api/v1/topic")]   
    
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
        public IActionResult AddTopic(TopicRequestModel model)
        {
            var result = _topicService.AddTopic(model.name, model.ownerId);
            return CreatedAtAction("addTopic", result);
        }

        [HttpPost("{topicId}/send")]
        public IActionResult SendMessage(MessageRequestModel messageRequestModel)
        {
            // Get topicId from route value
            var topicId_Route = Convert.ToInt32(HttpContext.GetRouteValue("topicId").ToString());
            var result = _messageService.SendMessage(topicId_Route, messageRequestModel.clientId, messageRequestModel.Content);
            return CreatedAtAction("SendMessage", result);
        }

        [HttpPost("{id}/send-message")]
        public IActionResult SendMessage([FromRoute]int id, [FromBody]SendMessageRequestModel requestModel)
        {
            var messageResponse = _topicService.SendMessage(id, requestModel);
            return CreatedAtAction("SendMessage", messageResponse);
        }
    }
}