using Microsoft.EntityFrameworkCore;

namespace Ginasio.Models
{
    [Keyless]
    public class JWTTokens
    {
        public string Token { get; set; }
        
        public string refToken { get; set; }
    }
}
