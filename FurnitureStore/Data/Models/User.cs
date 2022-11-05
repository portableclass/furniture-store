using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace FurnitureStore.Data.Models;

public class User : IdentityUser<Guid>
{
    public int WorkerId { get; set; }
    public virtual Worker Worker { get; set; }
    // public Role Role { get; set; }
}
