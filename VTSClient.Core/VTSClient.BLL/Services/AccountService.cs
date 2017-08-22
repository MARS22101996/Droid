using System.Threading.Tasks;
using AutoMapper;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Interfaces;

namespace VTSClient.Bll.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Login(LoginDto login)
        {
            var user = Mapper.Map<User>(login);

            var token = await _userRepository.Login(user);

            return token;
        }
    }
}
