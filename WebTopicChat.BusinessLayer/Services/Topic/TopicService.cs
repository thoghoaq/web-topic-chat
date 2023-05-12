using AutoMapper;
using WebTopicChat.BusinessLayer.DTOs.Response.Topic;
using WebTopicChat.DataAccessLayer.Repositories.Topic;

namespace WebTopicChat.BusinessLayer.Services.Topic
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

        public bool AddTopic(string name, int ownerId)
        {
            return _topicRepository.AddTopic(name, ownerId);
        }
    }
}
