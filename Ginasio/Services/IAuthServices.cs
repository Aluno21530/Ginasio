using Ginasio.Models;

namespace Ginasio.Services
{
    public interface IAuthServices
    {
        Task<string> GenerateTokenString(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<bool> Register(LoginUser user);
    }
}