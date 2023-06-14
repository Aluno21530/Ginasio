using Microsoft.EntityFrameworkCore;

namespace Ginasio.Models
{
    [Keyless]
    public class UsersLogin
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
