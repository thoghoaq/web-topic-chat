using AutoMapper;
<<<<<<< HEAD:WebTopicChat.BusinessLayer/Services/Message/MessageService.cs
using WebTopicChat.BusinessLayer.DTOs.Response.Message;
using WebTopicChat.DataAccessLayer.Repositories.Message;
=======
using WebTopicChat.Domain.DTOs.Response.Message;
using WebTopicChat.Infrastructure.Services.Message;
using WebTopicChat.Application.Repositories.Message;
>>>>>>> 40fe3ce9b7fee542c782a2542d0183f537774459:Infra/WebTopicChat.Infrastructure/Services/Message/MessageService.cs

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
