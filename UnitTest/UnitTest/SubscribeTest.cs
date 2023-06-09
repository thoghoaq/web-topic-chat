﻿using WebTopicChat.Application.Context;
using WebTopicChat.Application.Repositories.ClientTopic;

namespace Test.UnitTest
{
    public class SubscribeTest
    {
        private readonly TopicChatContext chatContext = new TopicChatContext();

        [Theory]
        [InlineData(3, 1)]
        [InlineData(1, 3)]
        public void SubTestSuccess(int clientId, int topicId)
        {
            ClientTopicRepository clientTopicRepository = new ClientTopicRepository(chatContext);
            var clientTopic = clientTopicRepository.AddClientTopic(clientId, topicId);
            Assert.Equal(clientId, clientTopic.ClientId);
            Assert.Equal(topicId, clientTopic.TopicId);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 6)]
        [InlineData(2, 6)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void SubTestFailed(int clientId, int topicId)
        {
            ClientTopicRepository clientTopicRepository = new ClientTopicRepository(chatContext);
            var clientTopic = clientTopicRepository.AddClientTopic(clientId, topicId);
            Assert.True(clientTopic == null);
        }

        [Theory]
        [InlineData(2, 1)]
        public void UnsubTest(int clientId, int topicId)
        {
            ClientTopicRepository clientTopicRepository = new ClientTopicRepository(chatContext);
            var clientTopic = clientTopicRepository.RemoveClientTopic(clientId, topicId);
            Assert.True(clientTopic);
        }
    }
}
