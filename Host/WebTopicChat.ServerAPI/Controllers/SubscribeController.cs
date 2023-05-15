using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD:WebTopicChat.ServerAPI/Controllers/SubscribeController.cs
using Microsoft.AspNetCore.SignalR;
using WebTopicChat.BusinessLayer.Services.Sub;
=======
using System.Net;
using WebTopicChat.Infrastructure;
using WebTopicChat.Infrastructure.Services.Sub;
>>>>>>> 40fe3ce9b7fee542c782a2542d0183f537774459:Host/WebTopicChat.ServerAPI/Controllers/SubscribeController.cs

namespace WebTopicChat.ServerAPI.Controllers
{
    [ApiController]
<<<<<<< HEAD:WebTopicChat.ServerAPI/Controllers/SubscribeController.cs
    [Route("topic/{topicId}")]
=======
    [Route("api/v1/topics/{topicID}/sub")]
>>>>>>> 40fe3ce9b7fee542c782a2542d0183f537774459:Host/WebTopicChat.ServerAPI/Controllers/SubscribeController.cs
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
