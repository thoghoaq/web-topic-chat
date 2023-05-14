using AutoMapper;
using WebTopicChat.BusinessLayer.DTOs.Response.Message;
using WebTopicChat.DataAccessLayer.Repositories.Message;

namespace WebTopicChat.BusinessLayer.Services.Message
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

        public MessageResponseModel SendMessage(int topicId, int clientId, string Msg)
        {
            var result = _MessageRepository.SendMessage(topicId, clientId, Msg);
            return _mapper.Map<MessageResponseModel>(result);
        }
        
        public List<MessageResponseModel> GetMessageOfTopic(int topicId)
        {
            var result = _MessageRepository.GetListOfTopic(topicId);
            return _mapper.Map<List<MessageResponseModel>>(result);

        }
    }
}
