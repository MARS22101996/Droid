using System.Threading.Tasks;
using VTSClient.DAL.Entities;

namespace VTSClient.DAL.Interfaces
{
	public interface IUserRepository
	{
        Task<string> Login(User user);
	}
}
