using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Auth;
using WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Messages;
using WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Topics;
using WebTopicChat.Infrastructure.Extensions.AutoMapper.Modules.Sub;


namespace WebTopicChat.Infrastructure.Extensions.AutoMapper.Config
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
                mc.ConfigMessageRequestModule();
                mc.ConfigSubModule();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
