using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Auth;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Messages;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Topics;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Sub;


namespace WebTopicChat.BusinessLayer.Extensions.AutoMapper.Config
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new (mc =>
            {
                mc.ConfigAuthModule();
                mc.ConfigTopicModule();
                mc.ConfigMessageModule();
                mc.ConfigSubModule();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
