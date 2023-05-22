using Microsoft.AspNetCore.Identity;

namespace PartialviewPage.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }

    }
}
