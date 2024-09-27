using Microsoft.AspNetCore.Identity;

namespace SurfsUpv3.Models
{
    public class UserProfile : IdentityUser
    {
        public string? Name { get; set; }
    }
}
