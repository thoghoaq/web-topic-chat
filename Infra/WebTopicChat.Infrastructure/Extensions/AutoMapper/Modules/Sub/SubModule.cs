using AutoMapper;
using WebTopicChat.Domain.DTOs.View.Sub;
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Sub
{
    public static class SubModule
    {
        public static void ConfigSubModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ClientTopic, SubViewModel>().ReverseMap();
        }
    }
}
