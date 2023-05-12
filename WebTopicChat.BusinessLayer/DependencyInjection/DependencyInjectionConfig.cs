using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.BusinessLayer.Services.Message;
using WebTopicChat.BusinessLayer.Services.Auth;
using WebTopicChat.BusinessLayer.Services.Topic;
using WebTopicChat.DataAccessLayer.Context;
using WebTopicChat.DataAccessLayer.Repositories.Client;
using WebTopicChat.DataAccessLayer.Repositories.Message;
using WebTopicChat.DataAccessLayer.Repositories.Topic;

namespace WebTopicChat.BusinessLayer.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, TopicChatContext>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddScoped<ITopicServices, TopicService>();

            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageServices, MessageService>();

            return services;
        }
    }
}
