﻿namespace WebTopicChat.Application.Repositories.ClientTopic
{
    public interface IClientTopicRepository
    {
        dynamic? AddClientTopic(int clientId, int topicId);
        bool RemoveClientTopic(int clientId, int topicId);
        public dynamic? GetClientTopic(int clientId, int topicId);
    }
}
