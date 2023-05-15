using AutoMapper;
using WebTopicChat.Domain.DTOs.Response.Topic;
using WebTopicChat.Application.Repositories.Topic;
using WebTopicChat.Domain.DTOs.Response.Message;
using WebTopicChat.Domain.DTOs.Request.Topic;
using WebTopicChat.Application.Repositories.Message;

namespace WebTopicChat.Infrastructure.Services.Topic
{
    public class TopicService : ITopicServices
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public TopicService(ITopicRepository topicRepository, IMapper mapper, IMessageRepository messageRepository)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
            _messageRepository = messageRepository;
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

        public MessageResponseModel SendMessage(int id, SendMessageRequestModel requestModel)
        {
            var message = _messageRepository.CreateMessage(id,requestModel.SenderId, requestModel.Content);
            return _mapper.Map<MessageResponseModel>(_messageRepository.GetMessage(message.Id));
        }
    }
}
