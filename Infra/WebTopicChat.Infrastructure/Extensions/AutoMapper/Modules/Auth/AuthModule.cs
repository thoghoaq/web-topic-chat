using AutoMapper;
using WebTopicChat.Domain.DTOs.View.Auth;
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Auth
{
    public static class AuthModule
    {
        public static void ConfigAuthModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Client, LoginViewModel>().ReverseMap();
        }
    }
}
