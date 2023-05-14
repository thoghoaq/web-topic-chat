using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebTopicChat.BusinessLayer.Services.Sub;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("topic/{topicId}")]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubService _subscribeService;

        public SubscribeController(ISubService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost("sub")]
        public IActionResult SubscribePost(int clientId, int topicId)
        {
            var result = _subscribeService.Subscribe(clientId, topicId);
            if (result != null)
                return CreatedAtAction("SubscribePost", result);
            else
                return Conflict();
        }

        [HttpPut("unsub")]
        public IActionResult UnsubscribePut(int clientId, int topicId)
        {
            var result = _subscribeService.Unsubscribe(clientId, topicId);
            if (result == true)
                return NoContent();
            else
                return NotFound();
        }
    }
}
