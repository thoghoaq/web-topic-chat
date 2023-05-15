using AutoMapper;
using WebTopicChat.Domain.DTOs.Request.Message;
using WebTopicChat.Domain.DTOs.Response.Message;
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Messages
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
                )
                .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }

        public static void ConfigMessageRequestModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Message, MessageRequestModel>().ReverseMap();
        }
    }
}
