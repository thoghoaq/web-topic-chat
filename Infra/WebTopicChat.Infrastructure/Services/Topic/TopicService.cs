using AutoMapper;
using WebTopicChat.Domain.DTOs.Response.Topic;
using WebTopicChat.Application.Repositories.Topic;

namespace WebTopicChat.Infrastructure.Services.Topic
{
    public class TopicService : ITopicServices
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        public TopicService(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public List<TopicResponseModel> GetTopics()
        {
            var result = _topicRepository.GetList();
            return _mapper.Map<List<TopicResponseModel>>(result);
        }

        public TopicResponseModel AddTopic(string name, int ownerId)
        {
            return _mapper.Map<TopicResponseModel>(_topicRepository.AddTopic(name, ownerId));
        }
    }
}
