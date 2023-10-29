using Microsoft.AspNetCore.Identity;

namespace W43BankingWebApp.Models.Identity
{
    public class BankAppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
