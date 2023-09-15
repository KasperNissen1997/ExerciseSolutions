using Microsoft.AspNetCore.Identity;

namespace ContosoUniversity3.Models.Identity
{
    public class ContosoUser : IdentityUser
    {
        public string? MyCustomProperty { get; set; }
    }
}
