using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookMyShowTask.Models
{
    public class UserDetail:IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
