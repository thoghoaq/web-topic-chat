﻿using WebTopicChat.Application.Context;

namespace WebTopicChat.Application.Repositories.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly TopicChatContext _context;

        public ClientRepository(TopicChatContext context)
        {
            _context = context;
        }

        public Domain.Entities.Client? Create(string userName, string password, string displayName)
        {
            try
            {
                var entity = new Domain.Entities.Client()
                {
                    UserName = userName,
                    Password = password,
                    DisplayName = displayName
                };
                _context.Clients.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch 
            {
                return null;
            }
        }

        public dynamic? Get(string userName, string password)
        {
            var client = _context.Clients.SingleOrDefault(e => e.UserName.Equals(userName) && e.Password.Equals(password));
            return client;
        }
    }
}
