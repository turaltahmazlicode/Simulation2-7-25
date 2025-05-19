using System.ComponentModel.DataAnnotations;

namespace Simulation2_7_25.DAL.Models;
public class Doctor : BaseEntity
{
    [Required, MinLength(2), MaxLength(30)]
    public string Name { get; set; }

    [Required, MinLength(2), MaxLength(40)]
    public string Surname { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    public string? TwitterUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? LinkedinUrl { get; set; }

    public ICollection<Profession>? Professions { get; set; }
}
