using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTopicChat.Application.Repositories.Message
{
    public interface IMessageRepository
    {
        dynamic? GetListOfTopic(int topicId);
    }
}
