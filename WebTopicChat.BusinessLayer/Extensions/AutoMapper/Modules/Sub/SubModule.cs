using AutoMapper;
using WebTopicChat.BusinessLayer.DTOs.View.Sub;
using WebTopicChat.DataAccessLayer.Entities;

namespace WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Sub
{
    public static class SubModule
    {
        public static void ConfigSubModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ClientTopic, SubViewModel>().ReverseMap();
        }
    }
}
