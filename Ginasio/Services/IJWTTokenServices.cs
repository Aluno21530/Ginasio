using Ginasio.Models;

namespace Ginasio.Services
{
    public interface IJWTTokenServices
    {
        JWTTokens Authenticate(UsersLogin user);
    }
}
