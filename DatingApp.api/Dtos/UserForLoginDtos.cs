using System.ComponentModel.DataAnnotations;

namespace DatingApp.api.Dtos
{
    public class UserForLoginDtos
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}