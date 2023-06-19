using System.ComponentModel.DataAnnotations;

namespace Ginasio.Models
{

    public class LoginUser
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
