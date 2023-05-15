using AutoMapper;
using WebTopicChat.Domain.DTOs.Response.Topic;
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Topics
{
    public static class TopicModule
    {
        public static void ConfigTopicModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Topic, TopicResponseModel>().ForMember(
                dest => dest.OwnerName,
                opt => opt.MapFrom(src => src.Owner.DisplayName)
                ).ReverseMap();
        }
    }
}
