using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FurnitureStore.Data.Models;

public class Role : IdentityRole<Guid>
{
    // [Display(Name="Administrator")]
    // Administrator,
    // [Display(Name="User")]
    // User,
    // [Display(Name="Manager")]
    // Manager,
    // [Display(Name="Financier")]
    // Financier
}
