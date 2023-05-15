using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebTopicChat.Infrastructure.Services.Message;
using WebTopicChat.Infrastructure.Services.Auth;

using WebTopicChat.Infrastructure.Services.Topic;
using WebTopicChat.Application.Context;
using WebTopicChat.Application.Repositories.Client;
using WebTopicChat.Application.Repositories.Message;
using WebTopicChat.Application.Repositories.Topic;

using WebTopicChat.Infrastructure.Services.Sub;
using WebTopicChat.Application.Repositories.ClientTopic;


namespace WebTopicChat.Infrastructure.DependencyInjection
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

            services.AddTransient<IClientTopicRepository, ClientTopicRepository>();
            services.AddScoped<ISubService, SubService>();

            return services;
        }
    }
}
