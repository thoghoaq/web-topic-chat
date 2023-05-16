using AutoMapper;
using WebTopicChat.Domain.DTOs.Response.Message;
using WebTopicChat.Application.Repositories.Message;

namespace WebTopicChat.Infrastructure.Services.Message
{
    public class MessageService : IMessageServices
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        
        public List<MessageResponseModel> GetMessageOfTopic(int topicId)
        {
            var result = _messageRepository.GetListOfTopic(topicId);
            return _mapper.Map<List<MessageResponseModel>>(result);

        }
    }
}
