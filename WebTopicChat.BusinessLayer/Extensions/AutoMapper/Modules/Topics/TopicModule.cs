using AutoMapper;
using WebTopicChat.BusinessLayer.DTOs.Response.Topic;
using WebTopicChat.DataAccessLayer.Entities;

namespace WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Topics
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
