using AutoMapper;
using WebTopicChat.BusinessLayer.DTOs.View.Auth;
using WebTopicChat.DataAccessLayer.Entities;

namespace WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Auth
{
    public static class AuthModule
    {
        public static void ConfigAuthModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Client, LoginViewModel>().ReverseMap();
        }
    }
}
