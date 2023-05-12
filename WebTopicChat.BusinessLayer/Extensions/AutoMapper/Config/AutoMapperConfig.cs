using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Auth;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Topics;

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
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
