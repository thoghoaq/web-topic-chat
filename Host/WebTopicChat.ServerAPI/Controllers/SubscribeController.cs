using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebTopicChat.Domain.DTOs.View.Sub;
using WebTopicChat.Infrastructure;
using WebTopicChat.Infrastructure.Services.Sub;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("api/v1/topic")]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubService _subscribeService;

        public SubscribeController(ISubService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost("sub")]
        public IActionResult SubscribePost([FromBody] SubViewModel subView)
        {
            var result = _subscribeService.Subscribe(subView.ClientId, subView.TopicId);
            if (result != null)
                return CreatedAtAction("SubscribePost", result);
            else
                return Conflict();
        }

        [HttpDelete("unsub")]
        public IActionResult UnsubscribePut(SubViewModel subView)
        {
            var result = _subscribeService.Unsubscribe(subView.ClientId, subView.TopicId);
            if (result == true)
                return NoContent();
            else
                return NotFound();
        }
    }
}
