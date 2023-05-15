<<<<<<< HEAD:WebTopicChat.DataAccessLayer/Repositories/Message/IMessageRepository.cs
﻿
namespace WebTopicChat.DataAccessLayer.Repositories.Message
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTopicChat.Application.Repositories.Message
>>>>>>> 40fe3ce9b7fee542c782a2542d0183f537774459:Core/WebTopicChat.Application/Repositories/Message/IMessageRepository.cs
{
    public interface IMessageRepository
    {
        dynamic? GetListOfTopic(int topicId);
        dynamic? SendMessage(int topicID, int clientID, string contentMsg);
    }
}
