using System.Threading.Tasks;
using VTSClient.BLL.Dto;

namespace VTSClient.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(LoginDto login);
    }
}
