using Microsoft.AspNetCore.Identity;

namespace TanITELEC1C.Data
{
    public class users : IdentityUser

    {
        public string? firstName {  get; set; }
        public string? lastName { get; set; }

    }
}
