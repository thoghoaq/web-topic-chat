using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.BusinessLayer.Services.Auth;
using WebTopicChat.DataAccessLayer.Context;
using WebTopicChat.DataAccessLayer.Repositories.Client;

namespace WebTopicChat.BusinessLayer.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, TopicChatContext>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
