using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.BusinessLayer.Extensions.AutoMapper.Modules.Auth;

namespace WebTopicChat.BusinessLayer.Extensions.AutoMapper.Config
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new (mc =>
            {
                mc.ConfigAuthModule();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
