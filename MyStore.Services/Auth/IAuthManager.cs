
using MyStore.DTOs;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserModel loginUserModel);
        Task<string> CreateToken();
    }
}
