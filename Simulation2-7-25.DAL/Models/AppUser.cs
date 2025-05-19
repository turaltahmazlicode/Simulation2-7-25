
using System.ComponentModel.DataAnnotations;

namespace Simulation2_7_25.DAL.Models;
public class AppUser : IdentityUser
{
    [Required, MinLength(2), MaxLength(30)]
    public string Name { get; set; }

    [Required, MinLength(2), MaxLength(40)]
    public string Surname { get; set; }
}
