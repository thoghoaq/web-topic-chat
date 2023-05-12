using AutoMapper;
using WebTopicChat.BusinessLayer.DTOs.Response.Message;
using WebTopicChat.DataAccessLayer.Entities;

namespace WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Messages
{
    public static class MessageModule
    {
        public static void ConfigMessageModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Message, MessageResponseModel>().ForMember(
                dest => dest.TopicName,
                opt => opt.MapFrom(src => src.Topic.Name)
                ).ForMember(
                dest => dest.SenderName,
                opt => opt.MapFrom(src => src.Sender.DisplayName)
                ).ReverseMap();
        }
    }
}
