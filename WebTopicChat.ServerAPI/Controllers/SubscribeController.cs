using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebTopicChat.BusinessLayer;
using WebTopicChat.BusinessLayer.Services.Sub;

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
    [Route("topics/{topicID}/sub")]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubService _subscribeService;

        public SubscribeController(ISubService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost]
        [ActionName(nameof(Subscribe))]
        public IActionResult Subscribe(int clientId, int topicID)
        {
            var result = _subscribeService.Subscribe(clientId, topicID);
            if (result != null)
                return CreatedAtAction("Subscribe", result);
            else
                return Conflict();
        }

        [HttpPut]
        public IActionResult Unsubscribe(int clientId, int topicID)
        {
            var result = _subscribeService.Unsubscribe(clientId, topicID);
            if (result == true)
                return NoContent();
            else
                return NotFound();
        }
    }
}
