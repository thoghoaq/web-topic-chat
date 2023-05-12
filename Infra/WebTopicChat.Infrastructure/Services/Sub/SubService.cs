using AutoMapper;
using System.Xml.Linq;
using WebTopicChat.Domain.DTOs.Response.Topic;
using WebTopicChat.Domain.DTOs.View.Sub;
using WebTopicChat.Domain.Entities;
using WebTopicChat.Application.Repositories.ClientTopic;

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
            //return _mapper.Map<TopicResponseModel>(_topicRepository.AddTopic(name, ownerId));
            return _mapper.Map<SubViewModel>(_clientTopicRepository.AddClientTopic(clientId, topicId));
            //return _clientTopicRepository.AddClientTopic(clientId, topicId);
        }
        public dynamic? Unsubscribe(int clientId, int topicId)
        {
            return _clientTopicRepository.RemoveClientTopic(clientId, topicId);
        }
    }
}
