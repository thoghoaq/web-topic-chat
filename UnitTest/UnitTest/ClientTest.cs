using WebTopicChat.Application.Context;
using WebTopicChat.Application.Repositories.Client;
using WebTopicChat.Domain.Entities;

namespace Test.UnitTest
{
    public class ClientTest
    {
        private readonly TopicChatContext chatContext = new TopicChatContext();

        [Theory]
        [InlineData("TestUser7", "07", "User07")]
        [InlineData("TestUser8", "08", "User08")]
        [InlineData("TestUser9", "09", "User09")]
        public void CretateClient(string userName, string password, string displayName)
        {
            ClientRepository clientRepository = new ClientRepository(chatContext);

            var newClient = clientRepository.Create(userName, password, displayName);
            Assert.Equal(userName, newClient.UserName);
            Assert.Equal(password, newClient.Password);
            Assert.Equal(displayName, newClient.DisplayName);
        }

        [Theory]
        [InlineData("TestUser1", "01")]
        [InlineData("TestUser2", "02")]
        [InlineData("TestUser3", "03")]
        public void GetClient(string userName, string password)
        {
            ClientRepository clientRepository = new ClientRepository(chatContext);

            var newClient = clientRepository.Get(userName, password);
            Assert.True(newClient != null);
            Assert.Equal(userName, newClient.UserName);
            Assert.Equal(password, newClient.Password);
        }
    }
}
