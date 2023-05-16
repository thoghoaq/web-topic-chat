using WebTopicChat.Application.Context;
using WebTopicChat.Application.Repositories.Message;
using WebTopicChat.Domain.Entities;

namespace UnitTest
{
    public class MessageTest
    {
        [Theory]
        [InlineData(11,2,"hello")]
        [InlineData(14, 2, "hi")]
        [InlineData(15, 1, "nice")]
        public void Test_CreateMessage(int idTopic, int senderId, string content)
        {
            TopicChatContext chatContext = new TopicChatContext();
            MessageRepository messageRepository = new MessageRepository(chatContext);
            var message = messageRepository.CreateMessage(idTopic, senderId, content);
            Assert.NotNull(message);
            Assert.Equal(content, message.Content);
            Assert.Equal(idTopic, message.TopicId);
            Assert.Equal(senderId, message.SenderId);
        }

        [Theory]
        [InlineData(1,7)]
        [InlineData(2,0)]
        //[InlineData(3,1)]
        public void Test_GetListOfTopic(int topicId, int resultlength)
        {
            TopicChatContext chatContext = new TopicChatContext();
            MessageRepository messageRepository = new MessageRepository(chatContext);
            var listMessage = messageRepository.GetListOfTopic(topicId);
            Assert.Equal(resultlength, listMessage.Count) ;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_GetMessage(int id) 
        {
            TopicChatContext chatContext = new TopicChatContext();
            MessageRepository messageRepository = new MessageRepository(chatContext);
            Message message = messageRepository.GetMessage(id);
            Assert.NotNull(message);
        }
    }
}
