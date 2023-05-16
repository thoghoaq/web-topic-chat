using WebTopicChat.Application.Context;
using WebTopicChat.Application.Repositories.Topic;

namespace UnitTest
{
    public class TopicTest
    {
        [Fact]
        public void Test_GetList() 
        {
            TopicChatContext chatContext = new TopicChatContext();
            TopicRepository topicRepository = new TopicRepository (chatContext);
            var listTopic = topicRepository.GetList();
            Assert.Equal(7,listTopic.Count);
        }


        [Theory]
        [InlineData ("", 1)]
        [InlineData("abc", 2)]
        //[InlineData("abc", 10)] 
        public void Test_AddTopic(string name, int ownerId) 
        {
            TopicChatContext chatContext = new TopicChatContext();
            TopicRepository topicRepository = new TopicRepository(chatContext);
            var topic = topicRepository.AddTopic(name, ownerId);
            Assert.True(topic!=null);
            Assert.Equal(name, topic.Name);
            Assert.Equal(ownerId, topic.OwnerId);
        }
    }
}