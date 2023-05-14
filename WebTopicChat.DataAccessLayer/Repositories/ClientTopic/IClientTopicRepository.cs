﻿namespace WebTopicChat.DataAccessLayer.Repositories.ClientTopic
{
    public interface IClientTopicRepository
    {
        dynamic? AddClientTopic(int clientId, int topicId);
        bool RemoveClientTopic(int clientId, int topicId);
        dynamic? GetClientTopic();
    }
}
