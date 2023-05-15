using AutoMapper;
<<<<<<< HEAD:WebTopicChat.BusinessLayer/Services/Sub/SubService.cs
using WebTopicChat.BusinessLayer.DTOs.View.Sub;
using WebTopicChat.DataAccessLayer.Repositories.ClientTopic;
=======
using System.Xml.Linq;
using WebTopicChat.Domain.DTOs.Response.Topic;
using WebTopicChat.Domain.DTOs.View.Sub;
using WebTopicChat.Domain.Entities;
using WebTopicChat.Application.Repositories.ClientTopic;
>>>>>>> 40fe3ce9b7fee542c782a2542d0183f537774459:Infra/WebTopicChat.Infrastructure/Services/Sub/SubService.cs

namespace WebTopicChat.Infrastructure.Services.Sub
{
    public class SubService : ISubService
    {
        private readonly IClientTopicRepository _clientTopicRepository;
        private readonly IMapper _mapper;

        public SubService(IClientTopicRepository clientTopicRepository, IMapper mapper)
        {
            _clientTopicRepository = clientTopicRepository; 
            _mapper = mapper;
        }

        public dynamic? Subscribe(int clientId, int topicId)
        {
            return _mapper.Map<SubViewModel>(_clientTopicRepository.AddClientTopic(clientId, topicId));
        }
        public bool Unsubscribe(int clientId, int topicId)
        {
            return _clientTopicRepository.RemoveClientTopic(clientId, topicId);
        }
    }
}
