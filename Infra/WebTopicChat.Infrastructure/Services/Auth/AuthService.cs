using AutoMapper;
using System.Net;
using WebTopicChat.Domain.DTOs.View.Auth;
using WebTopicChat.Domain.DTOs.View.Common;
using WebTopicChat.Application.Repositories.Client;
using WebTopicChat.Domain.DTOs.Request.Auth;

namespace WebTopicChat.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public AuthService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public KeyValuePair<MessageViewModel, LoginViewModel?> Login(string userName, string password)
        {
            var client = _clientRepository.Get(userName, password);
            if (client == null)
            {
                return new KeyValuePair<MessageViewModel, LoginViewModel?>(
                    new MessageViewModel { StatusCode = HttpStatusCode.Unauthorized, Message = "Wrong user name or password" }, 
                    null
                );
            }
            return new KeyValuePair<MessageViewModel, LoginViewModel?>(
                    new MessageViewModel { StatusCode = HttpStatusCode.OK, Message = "Authenticated" },
                    _mapper.Map<LoginViewModel>(client)
                );
        }

        public LoginViewModel Register(RegisterRequestModel model)
        {
            var client = _clientRepository.Create(model.UserName, model.Password, model.DisplayName);
            var viewModel = _mapper.Map<LoginViewModel>(client);
            return viewModel;
        }
    }
}
