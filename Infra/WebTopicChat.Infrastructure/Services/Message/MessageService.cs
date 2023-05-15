using AutoMapper;
using WebTopicChat.Domain.DTOs.Response.Message;
using WebTopicChat.Application.Repositories.Message;

namespace WebTopicChat.Infrastructure.Services.Message
{
    public class MessageService : IMessageServices
    {
        private readonly IMessageRepository _MessageRepository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepository MessageRepository, IMapper mapper)
        {
            _MessageRepository = MessageRepository;
            _mapper = mapper;
        }
        
        public List<MessageResponseModel> GetMessageOfTopic(int topicId)
        {
            var result = _MessageRepository.GetListOfTopic(topicId);
            return _mapper.Map<List<MessageResponseModel>>(result);

        }
    }
}
